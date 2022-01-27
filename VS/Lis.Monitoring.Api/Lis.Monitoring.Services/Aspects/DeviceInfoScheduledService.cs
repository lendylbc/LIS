using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Lis.Monitoring.Abstractions.Services;
using Lis.Monitoring.Services.Abstractions;
using Lis.Monitoring.Shared.Enums;

namespace Lis.Monitoring.Services.Aspects {
   public class DeviceInfoScheduledService : IScopedScheduleService {
      private ISnmpService _snmpService;
      private IModbusService _modbusService;
      private INotificationService _notificationService;
      public DeviceInfoScheduledService(ISnmpService snmpService, IModbusService modbusService, INotificationService notificationService) {
         _snmpService = snmpService;
         _modbusService = modbusService;
         _notificationService = notificationService;
      }

      public async Task DoWork(CancellationToken cancellationToken) {
         _snmpService.GetDevicesData();
         _modbusService.GetDevicesData();
       
         if(_modbusService.Errors?.Count > 0) {         
            await _notificationService.ZpracujUdalost(NotificationType.ValueCondition, NotificationSend.Email | NotificationSend.SMS, new Dictionary<string, object> {
               { "Conditions", _modbusService.Errors}
            });
         }

         await Task.CompletedTask;
      }
   }
}
