using Lis.Monitoring.Domain.Entities;

namespace Lis.Monitoring.Infrastructure.Abstractions
{
    public interface IMemberDbService
    {
        /// <summary>
        /// Vrací aktuálně přihlášeného uživatele, pokud není nikdo přihlášený, vrací null
        /// </summary>
        /// <returns>Aktuálně přihlášeného uživatele</returns>
        Member GetActualMember();
    }
}