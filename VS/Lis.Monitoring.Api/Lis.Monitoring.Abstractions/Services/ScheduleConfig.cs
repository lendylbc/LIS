﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lis.Monitoring.Abstractions.Services {
   public class ScheduleConfig<T> : IScheduleConfig<T> {
      public string CronExpression { get; set; }
      public TimeZoneInfo TimeZoneInfo { get; set; }
   }
}
