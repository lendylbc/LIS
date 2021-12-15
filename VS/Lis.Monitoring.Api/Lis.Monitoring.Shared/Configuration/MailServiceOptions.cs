namespace Lis.Monitoring.Shared.Configuration
{
	/// <summary>
	/// Nastavení mail service
	/// </summary>
	public class MailServiceOptions
	{
		/// <summary>
		/// Jméno nebo IP adresa SMTP serveru
		/// </summary>
		public string Host { get; set; }

		/// <summary>
		/// Port (nesmí být menší než 0)
		/// </summary>
		public int Port { get; set; }

		/// <summary>
		/// Uživatelské jméno na přihlášení k serveru
		/// </summary>
		public string Username { get; set; }

		/// <summary>
		/// Heslo pro přihlášení k serveru
		/// </summary>
		public string Heslo { get; set; }

		/// <summary>
		/// E-mail adresa, která bude použita k odesílání
		/// </summary>
		public string From { get; set; }
	}
}