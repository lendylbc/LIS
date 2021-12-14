using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lis.Monitoring.Abstractions.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lis.Monitoring.Infrastructure.Db
{
    public class DbServiceListeners
    {
        private List<Func<BeforeSaveContext, Task>> _beforeSaveListeners = new List<Func<BeforeSaveContext, Task>>();
        private readonly DbContext _context;
        private readonly Func<IChangeTrackingMember> _getMember;

        public DbServiceListeners(DbContext context, Func<IChangeTrackingMember> getUser)
        {
            _context = context;
            _getMember = getUser;
        }

        public bool IsInitalizationInProgress { get; set; }

        public void AddBeforeSaveListener(Func<BeforeSaveContext, Task> listener)
        {
            _beforeSaveListeners.Add(listener);
        }

        public async Task BeforeSaveAsync()
        {
            var ctx = new BeforeSaveContext(_context, IsInitalizationInProgress, _getMember);
            foreach (var listener in _beforeSaveListeners)
            {
                await listener(ctx);
            }
        }

        public void BeforeSave()
        {
            BeforeSaveAsync().Wait();
        }
    }
}