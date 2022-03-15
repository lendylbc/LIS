using System;
using System.Net;
using System.Net.Mail;
using Lis.Monitoring.Abstractions.Services;
using Serilog;

namespace Lis.Monitoring.Services.Aspects {
	/// <summary>
	/// Service pro odesílání e-mailů
	/// </summary>
	public class MailService : IMailService {
		private static readonly ILogger log = Serilog.Log.ForContext<MailService>();

		/// <summary>
		/// Konstruktor
		/// </summary>
		/// <param name="host">Adresa serveru, ze kterého se e-maily odesílají</param>
		/// <param name="port">Port serveru</param>
		/// <param name="username">Uživatelské jméno</param>
		/// <param name="password">Heslo</param>
		/// <param name="from">E-mail adresa, která bude uvedena v položce from (možno změnit v metodě odesílající e-mail)</param>
		public MailService(
			string host,
			int port,
			string username,
			string password,
			string from) {
			_host = host;
			_port = port;
			_username = username;
			_password = password;
			_from = from;
		}

		private readonly string _host;
		private readonly int _port;
		private readonly string _username;
		private readonly string _password;
		private readonly string _from;

		/// <summary>
		/// Odešle zprávu 
		/// </summary>
		/// <param name="predmet">Předmět zprávy</param>
		/// <param name="zprava">Zpráva</param>
		/// <param name="prijemci">Senzam příjemců</param>
		/// <param name="ccs">Seznam cc příjemců</param>
		/// <param name="bccs">Seznam bcc příjemců</param>
		/// <param name="isBodyHtml">Příznak, jetli je tělo zprávy html nebo není</param>
		/// <param name="from">Adresa, ze které se má e-mail odeslat. Pokud zůstane null, použije se globální nastavení z konfigurace</param>
		public void Send(string predmet, string zprava, string[] prijemci, string[] ccs = null, string[] bccs = null, bool isBodyHtml = true, string from = null) {
			if(string.IsNullOrEmpty(_host)) {
				return;
			}
			try {
				SmtpClient client = new SmtpClient(_host, _port) {
					UseDefaultCredentials = false
				};
				
				if(!string.IsNullOrEmpty(_username) || !string.IsNullOrEmpty(_password)) {
					client.Credentials = new NetworkCredential(_username, _password);
				} else {
					client.Credentials = null;
				}

				MailMessage message = new MailMessage {
					From = new MailAddress(from ?? _from),
					Subject = predmet,
					Body = zprava,
					To = { string.Join(",", prijemci) },
					IsBodyHtml = isBodyHtml,
				};

				if(ccs != null) {
					foreach(string cc in ccs) {
						message.CC.Add(cc);
					}
				}

				if(bccs != null) {
					foreach(string bcc in bccs) {
						message.Bcc.Add(bcc);
					}
				}

				client.Send(message);
			} catch(Exception ex) {
				log.Error("Error e-mail send: " + ex.Message);
			}
		}
	}
}