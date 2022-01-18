using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Lis.Monitoring.Abstractions.Entities;
using Lis.Monitoring.Abstractions.Services;
using Lis.Monitoring.Domain.Entities;
using Lis.Monitoring.Infrastructure;
using Lis.Monitoring.Shared.Enums;

namespace Lis.Monitoring.Services.Aspects {
	public class NotificationService : INotificationService
    {
		private readonly DbService _dbService;
		private readonly IMailService _mailService;

		public NotificationService(DbService dbService, IMailService mailService) {
			_dbService = dbService;
			_mailService = mailService;
		}

		/// <summary>
		/// Provede zpracování události daného typu
		/// </summary>
		/// <param name="typ">Typ události</param>
		/// <param name="odberatele">Seznam odběratelů události (notifikace)</param>
		/// <param name="data">Parametry dané události</param>
		/// <param name="filtrOdberNotifikaci">Možnost vypnout filtrování odběru notifikací (pokud false, odešle se notifikace bez ohledu na nastavení odběru)</param>
		public async Task ZpracujUdalost(int typ, IEnumerable<INotifikaceOdberSource> odberatele, Dictionary<string, object> data = null, bool filtrOdberNotifikaci = true) {
			if(filtrOdberNotifikaci) {
				odberatele = odberatele.Where(o => o.ZasilatNotifikace);
			}
			await OdeslatEmail((UdalostTyp)typ, odberatele, data);
		}

		/// <summary>
		/// Provede odeslání e-mailů daného typu všem zadaným uživatelům
		/// </summary>
		/// <param name="typ"></param>
		/// <param name="odberatele"></param>
		/// <param name="data"></param>
		/// <returns></returns>
		private async Task OdeslatEmail(UdalostTyp typ, IEnumerable<INotifikaceOdberSource> odberatele, Dictionary<string, object> data) {
			Sablona sablona = new Sablona();// await _dbService.Sablona.SingleOrDefaultAsync(s => (s.SablonaTyp & SablonaTyp.Email) > 0 && s.UdalostTyp == typ);
			if(sablona != null && odberatele.Any()) {
				string predmet = TransformujSablonu(sablona.Predmet, data);
				string zprava = TransformujSablonu(sablona.Zprava, data);
				// TODO předělat na odeslání přes bcc v případě více než jednoho odběratele
				_mailService.Send(predmet, zprava, odberatele.Select(x => x.Email).ToArray());
			}
		}

		private string TransformujSablonu(string sablona, Dictionary<string, object> placeholders) {
			var pattern = @"\$\{([^\{\}]+)\}";

			MatchCollection matches = Regex.Matches(sablona, pattern, RegexOptions.IgnoreCase);
			StringBuilder builder = new StringBuilder(sablona);
			for(int i = matches.Count - 1; i >= 0; i--) {
				Match match = matches[i];
				builder.Remove(match.Index, match.Length);
				string key = match.Groups[1].Value;
				if(placeholders.ContainsKey(key)) {
					builder.Insert(match.Index, placeholders[key]);
				} else {
					// TODO log missing data key
					builder.Insert(match.Index, "<<---CHYBNÁ DATA--->>");
				}
			}

			return builder.ToString();
		}
	}
}