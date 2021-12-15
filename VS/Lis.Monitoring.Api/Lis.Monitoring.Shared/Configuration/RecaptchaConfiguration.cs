namespace Lis.Monitoring.Shared.Configuration
{
	/// <summary>
	/// reCAPTCHA configuration
	/// </summary>
	public class RecaptchaConfiguration
	{
		/// <summary>
		/// Secret key
		/// </summary>
		public string SecretKey { get; set; }

		/// <summary>
		/// Site key
		/// </summary>
		public string SiteKey { get; set; }
	}
}