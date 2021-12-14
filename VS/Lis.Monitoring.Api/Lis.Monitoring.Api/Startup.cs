using System.Text;
using AutoMapper;
using Lis.Monitoring.Api.Authentication;
using Lis.Monitoring.Infrastructure;
//using AutoMapper;
using Lis.Monitoring.Services.Abstractions;
using Lis.Monitoring.Services.Entities;
using Lis.Monitoring.Shared.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Lis.Monitoring.Api {
	public class Startup {
		public Startup(IConfiguration configuration) {
			Configuration = configuration;

			DbOptions = Configuration.GetSection("Db").Get<DbServiceOptions>();
		}

		public IConfiguration Configuration { get; }
		public DbServiceOptions DbOptions { get; }
		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services) {
			services.AddEntityFrameworkSqlServer();

			services.AddDbContext<DbService>(options => {
				options.UseSqlServer(DbOptions.ConnectionString);
				//options.ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));
			}, ServiceLifetime.Transient);
			services.AddTransient<DbContext>(x => x.GetService<DbService>());

			services.AddControllers();

			//	Authentication
			var key = "Test KEY monitoring LIS temperature";
			services.AddAuthentication(x => {
				x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(x => {
				x.RequireHttpsMetadata = false;
				x.SaveToken = true;
				x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters {
					ValidateIssuerSigningKey = true,
					ValidateIssuer = false,
					ValidateAudience = false,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key))
				};
			});

			services.AddSingleton<IAuthJwt>(new Auth(key));

			services.AddAutoMapper(typeof(Startup));

			services.AddScoped<IMemberService, MemberService>();
			services.AddScoped<IDeviceService, DeviceService>();

			services.AddSwaggerGen(c => {
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Lis.Monitoring.Api", Version = "v1" });
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMapper autoMapper) {
			if(env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lis.Monitoring.Api v1"));
				autoMapper.ConfigurationProvider.AssertConfigurationIsValid();
			}



			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthentication();

			app.UseAuthorization();

			app.UseEndpoints(endpoints => {
				endpoints.MapControllers();
			});
		}
	}
}
