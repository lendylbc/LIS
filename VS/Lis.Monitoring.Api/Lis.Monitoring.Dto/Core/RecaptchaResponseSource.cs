namespace Lis.Monitoring.Dto.Core
{
	/// <summary>
	/// Data transfer object pro vytvoření uživatele
	/// </summary>
	public class RecaptchaResponseSource : IRecaptchaResponseSource
	{
		/// <summary>
		/// Potvrzovací řetězec se služby reCaptcha
		/// </summary>
		public string GRecaptchaResponse { get; set; }
	}
}