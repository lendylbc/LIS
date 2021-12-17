using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lis.Monitoring.Abstractions.Services {
   public interface IScheduleConfig<T> {
      string CronExpression { get; set; }
      TimeZoneInfo TimeZoneInfo { get; set; }
   }
}
