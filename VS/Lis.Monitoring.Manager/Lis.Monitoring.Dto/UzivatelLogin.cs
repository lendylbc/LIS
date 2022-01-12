namespace Lis.Monitoring.Dto {
	/// <summary>
	/// Model pro přihlášení uživatele
	/// </summary>
	public class UzivatelLogin : BaseDto {
		/// <summary>
		/// Přihlašovací jméno 
		/// </summary>
		public string Username { get; set; }
		/// <summary>
		/// Heslo
		/// </summary>
		public string Password { get; set; }
	}
}