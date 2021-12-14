using System;

namespace Lis.Monitoring.Abstractions.Entities
{
    public interface IChangeTrackingMember
    {
        long Id { get; }
        string UserName { get; }
    }
}