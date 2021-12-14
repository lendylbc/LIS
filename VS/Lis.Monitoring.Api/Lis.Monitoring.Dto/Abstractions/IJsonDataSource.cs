using Newtonsoft.Json.Linq;

namespace Lis.Monitoring.Dto.Abstractions {
    public interface IJsonDataSource {
        /// <summary>
        /// Serializovaná data požadavku
        /// </summary>
        JObject Data { get; set; }
    }
}