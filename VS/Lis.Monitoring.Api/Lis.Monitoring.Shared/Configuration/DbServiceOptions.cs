namespace Lis.Monitoring.Shared.Configuration
{
	/// <summary>
	/// Nastavení databáze
	/// </summary>
	public class DbServiceOptions
	{
		/// <summary>
		/// Connection string k databázi
		/// </summary>
		public string ConnectionString { get; set; }

		/// <summary>
		/// Příznak, jestli se má provést automatická změna databázové struktury
		/// </summary>
		public bool AutoUpdate { get; set; }
	}
}