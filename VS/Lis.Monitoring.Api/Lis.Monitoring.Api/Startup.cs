using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using AutoMapper;
using Lis.Monitoring.Abstractions.Services;
using Lis.Monitoring.Api.Authentication;
using Lis.Monitoring.Api.Schedule;
using Lis.Monitoring.Infrastructure;
using Lis.Monitoring.Services.Abstractions;
using Lis.Monitoring.Services.Aspects;
using Lis.Monitoring.Services.Entities;
using Lis.Monitoring.Shared.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;

namespace Lis.Monitoring.Api {
	public class Startup {
		public Startup(IConfiguration configuration) {  //	, ILoggerFactory loggerFactory
			Configuration = configuration;

			ConfigureLogger(Configuration.GetSection("Logger").Get<Shared.Configuration.LoggerConfiguration>());

			_logger.Information($"Application pid: {Process.GetCurrentProcess().Id}");
			//_logger.LogInformation($"Application starting assets path: {WebAppConfiguration.AssetsPath}, virtual app path: {WebAppConfiguration.VirtualAppPath}");

			DbOptions = Configuration.GetSection("Db").Get<DbServiceOptions>();

			_jwtOptions = Configuration.GetSection("JWT").Get<JwtServiceOptions>();

			MailServiceOptions = Configuration.GetSection("MailService").Get<MailServiceOptions>();
			SmsServiceOptions = Configuration.GetSection("SmsService").Get<MailServiceOptions>();
			BeaconServiceOptions = Configuration.GetSection("BeaconService").Get<MailServiceOptions>();
			//RecaptchaOptions = Configuration.GetSection("Recaptcha").Get<RecaptchaConfiguration>();
		}

		/// <summary>
		/// Service pro logování
		/// </summary>
		private ILogger _logger;
		/// <summary>
		/// Specifikace pro JWT service auth
		/// </summary>
		private JwtServiceOptions _jwtOptions { get; }
		/// <summary>
		/// Root konfigurace aplikace
		/// </summary>
		public IConfiguration Configuration { get; }
		/// <summary>
		/// Specifikace pøipojení k databázi entit
		/// </summary>
		public DbServiceOptions DbOptions { get; }
		/// <summary>
		/// Specifikace pro service na odesílání e-mailù
		/// </summary>				
		private MailServiceOptions MailServiceOptions { get; }

		/// <summary>
		/// Specifikace pro service na odesílání SMS
		/// </summary>				
		private MailServiceOptions SmsServiceOptions { get; }
		/// <summary>
		/// Specifikace pro service na nastavení majáku
		/// </summary>				
		private MailServiceOptions BeaconServiceOptions { get; }
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

			services.AddCors(options => options.AddPolicy("CorsPolicy",
				 builder => builder.WithOrigins("https://localhost:44392", "https://localhost:8081", "http://localhost:8081")
					.AllowAnyMethod()
					.AllowAnyHeader()
					.AllowCredentials()

				 //builder => builder.AllowAnyOrigin()
				 //  .AllowAnyMethod()
				 //  .AllowAnyHeader()
				 //  .AllowCredentials()
				 ////.SetIsOriginAllowed(hostName => true)
				 ////.SetIsOriginAllowed(_ => true)
				 )
			);

			services.AddAutoMapper(typeof(Startup));

			//	Authentication			
			services.AddAuthentication(x => {
				x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(x => {
				//x.Events = new JwtBearerEvents {
				//	OnTokenValidated = context => {
				//		var userService = context.HttpContext.RequestServices.GetRequiredService<IMemberService>();
				//		var userId = Guid.Parse(context.Principal.Identity.Name);
				//		var user = userService.GetById(userId);
				//		if(user == null || !user.Active) {
				//			// return unauthorized if user no longer exists
				//			context.Fail("Unauthorized");
				//		}
				//		return Task.CompletedTask;
				//	}
				//};
				x.RequireHttpsMetadata = false;
				x.SaveToken = true;
				x.TokenValidationParameters = new TokenValidationParameters {
					ValidateIssuerSigningKey = true,
					ValidateIssuer = false,
					ValidateAudience = false,
					ValidateLifetime = true,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtOptions.Secret))
				};
			});

			services.AddSingleton<IAuthJwt>(new Auth(_jwtOptions.Secret));

			//services.AddSingleton<ILogger>(_logger);

			services.AddScoped<IMemberService, MemberService>();
			services.AddScoped<IDeviceService, DeviceService>();
			services.AddScoped<IDeviceParameterDataService, DeviceParameterDataService>();
			services.AddScoped<IDeviceParameterService, DeviceParameterService>();
			services.AddScoped<IDeviceParameterConditionService, DeviceParameterConditionService>();
			services.AddScoped<IConditionService, ConditionService>();

			services.AddSwaggerGen(c => {
				c.SwaggerDoc("v1", new OpenApiInfo {
					Title = "Lis.Monitoring.Api",
					Version = "v1",
					Description = "Complete LIS API description",
					//TermsOfService = new System.Uri("http://lis.cz/terms/"),
					Contact = new OpenApiContact {
						Name = "VisionQ s.r.o.",
						Email = "info@visionq.cz",
						Url = new System.Uri("https://visionq.cz/")
					}
				});

				OpenApiSecurityScheme securityScheme = new OpenApiSecurityScheme {
					Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
					Name = "Authorization",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.ApiKey
				};

				OpenApiSecurityRequirement security = new OpenApiSecurityRequirement {
					  {securityScheme, new string[] { }},
				 };

				c.AddSecurityDefinition("Bearer", securityScheme);
				c.AddSecurityRequirement(security);

				//Locate the XML file being generated by ASP.NET...
				//var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
				//var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

				//... and tell Swagger to use those XML comments.
				//c.IncludeXmlComments(xmlPath);
			});

			services.AddScoped<IScopedScheduleService, DeviceInfoScheduledService>();
			services.AddScoped<IScopedClearDataScheduleService, DataClearScheduledService>();
			services.AddScoped<ISnmpService, SnmpService>();
			services.AddScoped<IModbusService, ModbusService>();

			services.AddCronJob<DeviceScheduler>(c => {
				c.TimeZoneInfo = TimeZoneInfo.Local;
				c.CronExpression = @"* * * * *";
			});

			services.AddCronJob<DataClearScheduler>(c => {
				c.TimeZoneInfo = TimeZoneInfo.Local;
				c.CronExpression = @"0 1 * * *";
			});

			services.AddSingleton<IMailService>(new MailService(
				MailServiceOptions.Host,
				MailServiceOptions.Port,
				MailServiceOptions.Username,
				MailServiceOptions.Heslo,
				MailServiceOptions.From));
			services.AddSingleton<ISmsService>(new SmsService(
				SmsServiceOptions.Host,
				SmsServiceOptions.Port,
				SmsServiceOptions.Username,
				SmsServiceOptions.Heslo));
			services.AddSingleton<IBeaconService>(new BeaconService(
				BeaconServiceOptions.Host,
				BeaconServiceOptions.Port,
				BeaconServiceOptions.Username,
				BeaconServiceOptions.Heslo));
			//services.AddSingleton(RecaptchaOptions);
			services.AddScoped<INotificationService, NotificationService>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMapper autoMapper) {
			if(env.IsDevelopment() || env.IsProduction()) {
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lis.Monitoring.Api v1"));
				autoMapper.ConfigurationProvider.AssertConfigurationIsValid();
			}

			app.UseHsts();

			app.UseCors("CorsPolicy");

			//	Only for migrations
			//if(DbOptions.AutoUpdate) {
			//	DbService db = serviceProvider.GetService<DbService>();
			//	db.Database.Migrate();
			//}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthentication();

			app.UseAuthorization();

			//app.UseMiddleware(typeof(ErrorHandlingMiddleware));

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

			_logger = Serilog.Log.ForContext<Startup>();
			_logger.Information("INFO Start test");
			_logger.Debug("DEBUG Start test");
			_logger.Warning("WARNING Start test");
			_logger.Error("ERROR Start test");
		}
	}
}
