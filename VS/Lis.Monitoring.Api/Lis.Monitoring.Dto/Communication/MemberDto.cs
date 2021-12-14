using Lis.Monitoring.Dto.Core;

namespace Lis.Monitoring.Dto.Communication {
		/// <summary>
		/// Data transfer object pro vytvoření uživatele
		/// </summary>
		public class MemberDto : BaseDto<long?> {//, IRecaptchaResponseSource {
			/// <summary>
			/// Jméno uživatele
			/// </summary>
			public string Name { get; set; }
			/// <summary>
			/// Příjmění uživatele
			/// </summary>
			public string Surname { get; set; }
			/// <summary>
			/// Email (uživatelské jméno) uživatele
			/// </summary>
			public string Email { get; set; }
			/// <summary>
			/// Heslo
			/// </summary>
			public string Password { get; set; }
			//      /// <summary>
			//      /// Pro jaký subjekt se chce uživatel registrovat
			//      /// </summary>
			//   public string Ico { get; set; }
			///// <summary>
			///// Potvrzovací řetězec se služby reCaptcha
			///// </summary>
			//public string GRecaptchaResponse { get; set; }
			//      /// <summary>
			//      /// Vyjádření souhlasu se smluvními podmínkami
			//      /// </summary>
			//   public bool SouhlasSmluvniPodminky { get; set; }
			/// <summary>
			/// Příznak odběru notifikací
			/// </summary>
			public bool ZasilatNotifikace { get; set; }
		}
	}
