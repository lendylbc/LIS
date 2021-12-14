namespace Lis.Monitoring.Abstractions.Entities
{
	/// <summary>
	/// Entita
	/// </summary>
	public interface IEntity<out TId>
		where TId : struct
	{
		/// <summary>
		/// Identifikátor entity
		/// </summary>
		TId Id { get; }

		/// <summary>
		/// Příznak, jestli je entita nově vkládaná do DB
		/// </summary>
		bool IsNew { get; }
	}
}