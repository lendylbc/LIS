using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Lis.Monitoring.Abstractions.Services;
using Lis.Monitoring.Services.Aspects;
using Microsoft.Extensions.DependencyInjection;

namespace Lis.Monitoring.Api.Schedule {
	public class DataClearScheduler : CronJobServiceBase {

		private readonly IServiceProvider _serviceProvider;

		public DataClearScheduler(IScheduleConfig<DataClearScheduler> config, IServiceProvider serviceProvider)
			 : base(config.CronExpression, config.TimeZoneInfo) {
			_serviceProvider = serviceProvider;
		}

		public override Task StartAsync(CancellationToken cancellationToken) {
			return base.StartAsync(cancellationToken);
		}

		public override async Task DoWork(CancellationToken cancellationToken) {
			using var scope = _serviceProvider.CreateScope();
			var svc = scope.ServiceProvider.GetRequiredService<IScopedClearDataScheduleService>();
			await svc.DoWork(cancellationToken);
		}

		public override Task StopAsync(CancellationToken cancellationToken) {
			return base.StopAsync(cancellationToken);
		}
	}
}