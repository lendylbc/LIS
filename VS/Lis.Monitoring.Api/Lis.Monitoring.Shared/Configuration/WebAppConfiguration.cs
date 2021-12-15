using System;
using System.IO;

namespace Lis.Monitoring.Shared.Configuration {
	public static class WebAppConfiguration
	{
		/// <summary>
		/// Virtuální cesta k aplikaci.
		/// Při adrese "http://api.lis.cz/aplikace" vrací "aplikace".
		/// </summary>
		public static string VirtualAppPath { get; private set; }

		/// <summary>
		/// Cesta k assets. Normalizováno končící "/".
		/// </summary>
		public static string AssetsPath { get; private set; }

		/// <summary>
		/// Adresa API
		/// <example>https://api.lis.cz/v1/</example>
		/// </summary>
		public static string ApiRootUrl { get; set; }

        /// <summary>
        /// Relativní cesta ke stránce, která zobrazuje komponentu na reset hesla.
        /// Placeholder {id} bude nahrazen jedinečným identifikátorem uživatele, který požádal o změnu hesla
        /// <example>heslo-nove/{id}</example>
        /// </summary>
        public static string HesloResetPath { get; set; }

        /// <summary>
        /// Relativní cesta ke stránce, která zobrazuje komponentu pro aktivaci uživatelského konta
        /// Placeholder {id} bude nahrazen jedinečným identifikátorem nově registrovaného uživatele
        /// <example>aktivace/{id}</example>
        /// </summary>
        public static string AktivacePath { get; set; }

		/// <summary>
		/// Nahraje settings z konfigurace (env/configuration).
		/// </summary>
		//public static void Load(IWebHostEnvironment env, IConfiguration configuration, string webAppConfigurationKey = "WebApp") {
		//	VirtualAppPath = configuration[$"{webAppConfigurationKey}:VirtualAppPath"];
		//	ApiRootUrl = configuration[$"{webAppConfigurationKey}:ApiRootUrl"];
		//	AssetsPath = GetAssetPath(env, configuration[$"{webAppConfigurationKey}:AssetsPath"]);
		//	HesloResetPath = configuration[$"{webAppConfigurationKey}:HesloResetPath"];
		//	AktivacePath = configuration[$"{webAppConfigurationKey}:AktivacePath"];
		//}

		/// <summary>
		/// Vrací cestu asset pro daný soubor s přidáním správné adresy před jméno souboru.
		/// </summary>
		public static string GetAssetsPath(string filePath)
		{
			if (filePath == null)
			{
				throw new ArgumentNullException(nameof(filePath));
			}

			if (filePath.StartsWith("/"))
			{
				filePath = filePath.Remove(0, 1);
			}

			return $"{AssetsPath}{filePath}";
		}

		//private static string GetAssetPath(IHostingEnvironment env, string assetsPath)
		//{
		//	if (string.IsNullOrEmpty(assetsPath) || assetsPath == "(none)")
		//	{
		//		var hashPath = System.IO.Path.Combine(env.WebRootPath, "assets", "hash");
		//		if (!File.Exists(hashPath))
		//		{
		//			throw new ArgumentException($"Assets hash file not found ({hashPath})");
		//		}
		//		assetsPath = $"/assets/{File.ReadAllText(hashPath)}/";
		//	}
		//	else if (!assetsPath.EndsWith("/"))
		//	{
		//		assetsPath = assetsPath + "/";
		//	}
		//	return assetsPath;
		//}
	}
}