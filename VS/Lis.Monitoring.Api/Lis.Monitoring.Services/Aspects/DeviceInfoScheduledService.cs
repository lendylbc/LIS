using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Lis.Monitoring.Abstractions.Services;
using Lis.Monitoring.Services.Abstractions;

namespace Lis.Monitoring.Services.Aspects {
   public class DeviceInfoScheduledService : IScopedScheduleService {
      ISnmpService _snmpService;
      public DeviceInfoScheduledService(ISnmpService snmpService) {
         _snmpService = snmpService;
      }

      public async Task DoWork(CancellationToken cancellationToken) {
         _snmpService.GetDevicesData();
          await Task.CompletedTask;
      }
   }
}
