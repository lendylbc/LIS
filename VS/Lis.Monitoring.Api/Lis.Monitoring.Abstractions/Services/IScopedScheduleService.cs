using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lis.Monitoring.Abstractions.Services {
   public interface IScopedScheduleService {
      Task DoWork(CancellationToken cancellationToken);
   }
}
