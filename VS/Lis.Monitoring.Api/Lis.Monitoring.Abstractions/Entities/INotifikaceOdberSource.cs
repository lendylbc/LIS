namespace Lis.Monitoring.Abstractions.Entities {
	public interface INotifikaceOdberSource {
		string Email { get; }
		string? Phone { get; set; }
		bool SendNotifications { get; }
	}
}