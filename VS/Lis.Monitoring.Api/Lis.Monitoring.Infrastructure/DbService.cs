using System;
using System.Threading;
using System.Threading.Tasks;
using Lis.Monitoring.Domain.Entities;
using Lis.Monitoring.Abstractions;
using Microsoft.EntityFrameworkCore;
using Lis.Monitoring.Infrastructure.Db;
using Lis.Monitoring.Infrastructure.Abstractions;

namespace Lis.Monitoring.Infrastructure {
	public partial class DbService : DbContext {
		private readonly IServiceProvider _serviceProvider;
		private DbServiceListeners _listeners;
		private Member _currentMember;

		public DbService(DbContextOptions<DbService> options, IServiceProvider serviceProvider)
			: base(options) {
			_serviceProvider = serviceProvider;
			//_listeners = new DbServiceListeners(this, () => CurrentMember);
			//_listeners.AddMetadataHandling();
		}

		public Member CurrentMember {
			get {
				if(_currentMember == null && _serviceProvider != null) {
					var userService = (IMemberDbService)_serviceProvider.GetService(typeof(IMemberDbService));
					_currentMember = userService.GetActualMember();
				}

				return _currentMember;
			}
		}

		public override int SaveChanges(bool acceptAllChangesOnSuccess) {
			_listeners.BeforeSave();
			return base.SaveChanges(acceptAllChangesOnSuccess);
		}

		public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken()) {
			await _listeners.BeforeSaveAsync();
			return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			base.OnModelCreating(modelBuilder);

			ApplyEntityConfigurations(modelBuilder);
			
			//DataSeed(modelBuilder);
		}
	}

}