using System;
using System.Collections.Generic;
using Lis.Monitoring.Abstractions.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Lis.Monitoring.Infrastructure.Db
{
    public static class EntityEntryListExtensions
    {
        public static IList<EntityEntry> ApplyUpdateMetadataHandling(this IList<EntityEntry> changes, string userName, long? userId)
        {
            var updatedTime = DateTimeOffset.Now;
            foreach (var change in changes)
            {
                //if (change.Entity is IUpdateInfoEntity<Guid> entity && change.State != EntityState.Unchanged)
                //{
                //    if (change.State == EntityState.Added)
                //    {
                //        entity.DatumVytvoreni = updatedTime;
                //        entity.UzivatelVytvoreni = userName;
                //        entity.UzivatelVytvoreniId = userId;
                //    }
                //    entity.DatumZmena = updatedTime;
                //    entity.UzivatelZmena = userName;
                //    entity.UzivatelZmenaId = userId;
                //} else if (change.Entity is IDatumVytvoreniSourceEntity createdEntity && change.State == EntityState.Added) {
                //    createdEntity.DatumVytvoreni = updatedTime;
                //}
            }
            return changes;
        }
    }
}