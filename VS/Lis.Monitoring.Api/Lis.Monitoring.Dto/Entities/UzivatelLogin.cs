namespace Lis.Monitoring.Dto.Entities
{
    /// <summary>
    /// Model pro přihlášení uživatele
    /// </summary>
    public class UzivatelLogin
    {
        /// <summary>
        /// Přihlašovací jméno 
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Heslo
        /// </summary>
        public string Heslo { get; set; }
    }
}