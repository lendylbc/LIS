using Lis.Monitoring.Shared.Configuration;
using Microsoft.Extensions.Configuration;

namespace Lis.Monitoring.Shared.Helper {
	public static class StartupHelper
	{
		/// <summary>
		/// Inicializuje logování a loadne základní konfiguraci
		/// </summary>
		/// <param name="env"></param>
		/// <param name="loggerFactory"></param>
		/// <param name="webAppConfigurationKey"></param>
		/// <returns></returns>
		//public static IConfigurationRoot Initialize(IWebHostEnvironment env, ILoggerFactory loggerFactory, string webAppConfigurationKey = "WebApp") {
		//	var configuration = BaseConfiguration.Create(env, loggerFactory);
		//	WebAppConfiguration.Load(env, configuration, webAppConfigurationKey);
		//	return configuration;
		//}
	}
}