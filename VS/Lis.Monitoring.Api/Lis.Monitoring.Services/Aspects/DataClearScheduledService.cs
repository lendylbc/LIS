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
   public class DataClearScheduledService : IScopedClearDataScheduleService {
      private static readonly ILogger log = Serilog.Log.ForContext<DataClearScheduledService>();

      private IDeviceParameterDataService _deviceParameterDataService;
      public DataClearScheduledService(IDeviceParameterDataService deviceParameterDataService) {
         _deviceParameterDataService = deviceParameterDataService;
      }

      public async Task DoWork(CancellationToken cancellationToken) {
         try {
            _deviceParameterDataService.DeleteOldData();
            log.Debug("Device data clear.");
         } catch(Exception ex) {
            log.Error(ex.Message);
         }
         
         await Task.CompletedTask;
      }
   }
}