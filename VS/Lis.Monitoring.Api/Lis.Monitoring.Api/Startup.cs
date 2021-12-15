using System.Diagnostics;
using System.Text;
using AutoMapper;
using Lis.Monitoring.Api.Authentication;
using Lis.Monitoring.Infrastructure;
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
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;
//using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Lis.Monitoring.Api {
	public class Startup {
		public Startup(IConfiguration configuration) {  //	, ILoggerFactory loggerFactory
			Configuration = configuration;

			ConfigureLogger(Configuration.GetSection("Logger").Get<Shared.Configuration.LoggerConfiguration>());

			Serilog.ILogger log = Serilog.Log.ForContext<Startup>();
			log.Information("INFO");
			log.Debug("DEBUG");
			log.Warning("WARNING");
			log.Error("ERROR");

			log.Information($"Application pid: {Process.GetCurrentProcess().Id}");
			//_logger.LogInformation($"Application starting assets path: {WebAppConfiguration.AssetsPath}, virtual app path: {WebAppConfiguration.VirtualAppPath}");

			DbOptions = Configuration.GetSection("Db").Get<DbServiceOptions>();

			MailServiceOptions = Configuration.GetSection("MailService").Get<MailServiceOptions>();
			//RecaptchaOptions = Configuration.GetSection("Recaptcha").Get<RecaptchaConfiguration>();
		}

		/// <summary>
		/// Service pro logování
		/// </summary>
		//private ILogger _logger;
		/// <summary>
		/// Root konfigurace aplikace
		/// </summary>
		public IConfiguration Configuration { get; }
		/// <summary>
		/// Specifikace pøipojení k databázi entit
		/// </summary>
		public DbServiceOptions DbOptions { get; }
		/// <summary>
		/// Specifikace pøipojení k dokumentové databázi
		/// </summary>
		/// <summary>
		/// Specifikace pro service na odesílání e-mailù
		/// </summary>
		private MailServiceOptions MailServiceOptions { get; }
		///// <summary>
		///// Specifikace pro reCaptcha
		///// </summary>
		//private RecaptchaConfiguration RecaptchaOptions { get; }

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
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory, IMapper autoMapper) {
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

		protected void ConfigureLogger(Shared.Configuration.LoggerConfiguration options) {
			var logPath = options.LogFolderPath;
			Log.Logger = new Serilog.LoggerConfiguration()
				.MinimumLevel.Verbose()
				.MinimumLevel.Override("Microsoft", LogEventLevel.Information)
				.MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
				.MinimumLevel.Override("System", LogEventLevel.Warning)
				.WriteTo.Logger(l => l
					.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Information)
					.WriteTo.File(logPath + @"info_.log", rollingInterval: RollingInterval.Day, shared: true, restrictedToMinimumLevel: LogEventLevel.Information))
				.WriteTo.Logger(l => l
					.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Debug)
					.WriteTo.File(logPath + @"debug_.log", rollingInterval: RollingInterval.Day, shared: true, restrictedToMinimumLevel: LogEventLevel.Debug))
				.WriteTo.Logger(l => l
					.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Warning)
					.WriteTo.File(logPath + @"warn_.log", rollingInterval: RollingInterval.Day, shared: true, restrictedToMinimumLevel: LogEventLevel.Warning))
				.WriteTo.Logger(l => l
					.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Error)
					.WriteTo.File(logPath + @"error_.log", rollingInterval: RollingInterval.Day, shared: true, restrictedToMinimumLevel: LogEventLevel.Error))
				.Enrich.FromLogContext()
				.Enrich.WithMachineName()
				.Enrich.WithEnvironmentUserName()
				.Enrich.WithThreadId()
				.CreateLogger();



			//.WriteTo.Conditional(e => e.Level == LogEventLevel.Information).File(logPath + @"info_.log", rollingInterval: RollingInterval.Day, shared: true, restrictedToMinimumLevel: LogEventLevel.Information)





		}
	}
}
