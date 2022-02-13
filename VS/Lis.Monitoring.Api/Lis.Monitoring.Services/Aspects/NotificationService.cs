using System;
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
using Lis.Monitoring.Shared.Errors;

namespace Lis.Monitoring.Services.Aspects {
	public class NotificationService : INotificationService {
		private readonly DbService _dbService;
		private readonly IMailService _mailService;
		private readonly ISmsService _smsService;
		private readonly IBeaconService _beaconService;

		public NotificationService(DbService dbService, IMailService mailService, ISmsService smsService, IBeaconService beaconService) {
			_dbService = dbService;
			_mailService = mailService;
			_smsService = smsService;
			_beaconService = beaconService;
		}

		/// <summary>
		/// Provede zpracování události daného typu
		/// </summary>
		/// <param name="typ">Typ události</param>
		/// <param name="odberatele">Seznam odběratelů události (notifikace)</param>
		/// <param name="data">Parametry dané události</param>
		/// <param name="filtrOdberNotifikaci">Možnost vypnout filtrování odběru notifikací (pokud false, odešle se notifikace bez ohledu na nastavení odběru)</param>
		public async Task ZpracujUdalost(NotificationType notificationType, NotificationSend notificationSend, Dictionary<string, object> data = null, bool filtrOdberNotifikaci = true) {
			IEnumerable<INotifikaceOdberSource> odberatele = _dbService.Set<Member>().Where(o => o.SendNotifications);

			if((notificationSend & NotificationSend.Email) > 0) {
				await OdeslatEmail((NotificationType)notificationType, odberatele, data);
			}
			if((notificationSend & NotificationSend.SMS) > 0) {
				await OdeslatSms((NotificationType)notificationType, odberatele.Where(x => x.Phone != null), data);
			}
			if((notificationSend & NotificationSend.Beacon) > 0) {
				await BeaconOn();
			}
		}

		public async Task NotificationClear() {
			await BeaconOff();
		}

		/// <summary>
		/// Provede odeslání e-mailů daného typu všem zadaným uživatelům
		/// </summary>
		/// <param name="notificationType"></param>
		/// <param name="odberatele"></param>
		/// <param name="data"></param>
		/// <returns></returns>
		private async Task OdeslatEmail(NotificationType notificationType, IEnumerable<INotifikaceOdberSource> odberatele, Dictionary<string, object> data) {
			//Sablona sablona = new Sablona();// await _dbService.Sablona.SingleOrDefaultAsync(s => (s.SablonaTyp & SablonaTyp.Email) > 0 && s.UdalostTyp == typ);
			//if(sablona != null && odberatele.Any()) {
			string predmet = "Informace monitoringu"; //	 TransformujSablonu(sablona.Predmet, data);
			string zprava = TransformujSablonu("", data);
			_mailService.Send(predmet, zprava, odberatele.Select(x => x.Email).ToArray());
			//}
		}

		private async Task OdeslatSms(NotificationType notificationType, IEnumerable<INotifikaceOdberSource> odberatele, Dictionary<string, object> data) {
			string predmet = "Informace monitoringu"; //	 TransformujSablonu(sablona.Predmet, data);
			string zprava = "Chybový stav";
			_smsService.Send(predmet, zprava, odberatele.Select(x => x.Phone).ToArray());
		}

		private async Task BeaconOn() {
			_beaconService.LightOn();
		}

		private async Task BeaconOff() {
			_beaconService.LightOff();
		}

		private string TransformujSablonu(string sablona, Dictionary<string, object> placeholders) {
			StringBuilder builder = new StringBuilder(sablona);
			foreach(KeyValuePair<string, object> item in placeholders) {
				if(item.Value is List<ErrorParameterInfo>) {
					foreach(ErrorParameterInfo error in (item.Value as List<ErrorParameterInfo>)) {
						builder.AppendLine(error.ToString() + "<br>");
						//builder.Append(Environment.NewLine);
					}
				} else {
					builder.Append($"{item.Key} - {item.Value.ToString()}");
				}
			}
			return builder.ToString();
		}

		//private string TransformujSablonu(string sablona, Dictionary<string, object> placeholders) {
		//	var pattern = @"\$\{([^\{\}]+)\}";

		//	MatchCollection matches = Regex.Matches(sablona, pattern, RegexOptions.IgnoreCase);
		//	StringBuilder builder = new StringBuilder(sablona);
		//	for(int i = matches.Count - 1; i >= 0; i--) {
		//		Match match = matches[i];
		//		builder.Remove(match.Index, match.Length);
		//		string key = match.Groups[1].Value;
		//		if(placeholders.ContainsKey(key)) {
		//			builder.Insert(match.Index, placeholders[key]);
		//		} else {
		//			// TODO log missing data key
		//			builder.Insert(match.Index, "<<---CHYBNÁ DATA--->>");
		//		}
		//	}

		//	return builder.ToString();
		//}
	}
}