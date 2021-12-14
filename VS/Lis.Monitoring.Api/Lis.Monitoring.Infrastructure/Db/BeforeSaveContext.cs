using System;
using System.Collections.Generic;
using System.Linq;
using Lis.Monitoring.Abstractions.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Lis.Monitoring.Infrastructure.Db
{
    public class BeforeSaveContext
    {
        private readonly Func<IChangeTrackingMember> _getUser;

        public BeforeSaveContext(DbContext context, bool isInitialSave, 
            Func<IChangeTrackingMember> getUser)
        {
            Context = context;
            Changes = context.ChangeTracker.Entries().ToList();
            IsInitialSave = isInitialSave;
            _getUser = getUser;
        }

        public DbContext Context { get; }
        public IList<EntityEntry> Changes { get; }
        public bool IsInitialSave { get; }
        public IChangeTrackingMember User => _getUser();
    }
}