namespace Lis.Monitoring.Abstractions.Entities
{
    public interface INotifikaceOdberSource
    {
        string Email { get; }
        bool SendNotifications { get; }
    }
}