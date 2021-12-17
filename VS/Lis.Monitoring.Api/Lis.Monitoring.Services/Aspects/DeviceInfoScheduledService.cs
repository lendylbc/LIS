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
      IDeviceService _deviceService;
      public DeviceInfoScheduledService(IDeviceService deviceService) {
         _deviceService = deviceService;
      }

      public async Task DoWork(CancellationToken cancellationToken) {
        var dev = _deviceService.GetById(1);
         await Task.CompletedTask;
      }
   }
}
