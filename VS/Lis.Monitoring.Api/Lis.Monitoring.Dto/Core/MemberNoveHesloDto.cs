namespace Lis.Monitoring.Dto.Core
{
	/// <summary>
	/// Data transfer object pro změnu hesla
	/// </summary>
	public class MemberNoveHesloDto
	{
		/// <summary>
		/// Identifikátor uživatele - HesloResetKod
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// Nové heslo
		/// </summary>
		public string Heslo { get; set; }
	}
}