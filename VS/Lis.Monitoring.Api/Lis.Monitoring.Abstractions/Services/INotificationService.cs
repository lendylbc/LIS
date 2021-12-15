using System.Collections.Generic;
using System.Threading.Tasks;
using Lis.Monitoring.Abstractions.Entities;

namespace Lis.Monitoring.Abstractions.Services
{
    public interface INotificationService
    {
        /// <summary>
        /// Provede zpracování události daného typu
        /// </summary>
        /// <param name="typ">Typ události</param>
        /// <param name="odberatele">Seznam odběratelů události (notifikace)</param>
        /// <param name="data">Parametry dané události</param>
        /// <param name="filtrOdberNotifikaci">Možnost vypnout filtrování odběru notifikací (pokud false, odešle se notifikace bez ohledu na nastavení odběru)</param>
        //Task ZpracujUdalost(int typ, IEnumerable<INotifikaceOdberSource> odberatele, Dictionary<string, object> data = null, bool filtrOdberNotifikaci = true);
    }
}