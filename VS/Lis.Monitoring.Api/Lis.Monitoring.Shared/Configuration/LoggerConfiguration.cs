namespace Lis.Monitoring.Shared.Configuration
{
	public class LoggerConfiguration
	{
		private string _logFolderPath;

		public string LogFolderPath
		{
			get => _logFolderPath;
			set => _logFolderPath = value.EndsWith("\\") ? value : $"{value}\\";
		}
	}
}