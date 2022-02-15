using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Lis.Monitoring.Abstractions.Services;
using Lis.Monitoring.Services.Abstractions;
using Lis.Monitoring.Shared.Enums;
using Serilog;

namespace Lis.Monitoring.Services.Aspects {
   public class DeviceInfoScheduledService : IScopedScheduleService {
      private static readonly ILogger log = Serilog.Log.ForContext<DeviceInfoScheduledService>();

      private ISnmpService _snmpService;
      private IModbusService _modbusService;
      private INotificationService _notificationService;
      public DeviceInfoScheduledService(ISnmpService snmpService, IModbusService modbusService, INotificationService notificationService) {
         _snmpService = snmpService;
         _modbusService = modbusService;
         _notificationService = notificationService;
      }

      public async Task DoWork(CancellationToken cancellationToken) {
         try {
            _snmpService.GetDevicesData();
            _modbusService.GetDevicesData();
            log.Debug("Device info.");
			} catch (Exception ex) {
            log.Error(ex.Message);
			}
       
         if(_snmpService.NotifyErrors?.Count > 0 || _modbusService.NotifyErrors?.Count > 0) {         
            await _notificationService.ZpracujUdalost(NotificationType.ValueCondition, NotificationSend.Email | NotificationSend.SMS | NotificationSend.Beacon, new Dictionary<string, object> {
               { "Conditions", _modbusService.NotifyErrors}
            });
         } else {
            //if(_snmpService.ErrorsExists || _modbusService.ErrorsExists) {
            //   await _notificationService.NotificationClear();
            //}
            if(!_snmpService.ErrorsExists && !_modbusService.ErrorsExists) {
               await _notificationService.NotificationClear();
            }
         }
      
         await Task.CompletedTask;
      }
   }
}
