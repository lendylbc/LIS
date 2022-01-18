using System.ComponentModel.DataAnnotations;
using Lis.Monitoring.Abstractions.Entities;
using Lis.Monitoring.Shared.Enums;

namespace Lis.Monitoring.Domain.Entities {
	/// <summary>
	/// Entita šablona
	/// </summary>
	public class Sablona : Entity
	{
		/// <summary>
		/// Název šablony
		/// </summary>
		[Required]
		[MaxLength(100)]
		public string Nazev { get; set; }

		/// <summary>
		/// Předmět šablony
		/// </summary>
		[MaxLength(100)]
		public string Predmet { get; set; }

		/// <summary>
		/// Tělo samotné zprávy
		/// </summary>
		[Required]
		public string Zprava { get; set; }

		/// <summary>
		/// Definice typu šablony
		/// (Jednu šablonu je možné použít pro více typů najednou)
		/// </summary>
		public SablonaTyp SablonaTyp { get; set; }

		/// <summary>
		/// Definice typu události, se kterou je šablona spojena
		/// </summary>
		public UdalostTyp UdalostTyp { get; set; }
	}
}