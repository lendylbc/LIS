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
      IModbusService _modbusService;
      public DeviceInfoScheduledService(ISnmpService snmpService, IModbusService modbusService) {
         _snmpService = snmpService;
         _modbusService = modbusService;
      }

      public async Task DoWork(CancellationToken cancellationToken) {
         _snmpService.GetDevicesData();
         _modbusService.GetDevicesData();
         await Task.CompletedTask;
      }
   }
}
