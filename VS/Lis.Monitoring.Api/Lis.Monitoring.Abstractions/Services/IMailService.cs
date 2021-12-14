namespace Lis.Monitoring.Abstractions.Services
{
	/// <summary>
	/// Abstrakce service pro odesílání e-mailů
	/// </summary>
	public interface IMailService
	{
		/// <summary>
		/// Odešle zprávu 
		/// </summary>
		/// <param name="predmet">Předmět zprávy</param>
		/// <param name="zprava">Zpráva</param>
		/// <param name="prijemci">Senzam příjemců</param>
		/// <param name="ccs">Seznam cc příjemců</param>
		/// <param name="bccs">Seznam bcc příjemců</param>
		/// <param name="isBodyHtml">Příznak, jestli je tělo zprávy html nebo není</param>
		/// <param name="from">Adresa, ze které se má e-mail odeslat. Pokud zůstane null, použije se globální nastavení z konfigurace</param>
		void Send(string predmet, string zprava, string[] prijemci, string[] ccs = null, string[] bccs = null, bool isBodyHtml = true, string from = null);
	}
}