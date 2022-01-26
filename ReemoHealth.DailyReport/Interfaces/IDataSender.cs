using ReemoHealth.DailyReport.Model;

namespace ReemoHealth.DailyReport.Interfaces;

public interface IDataSender: IDisposable
{
    Task InitializeAsync();
    Task SendDataAsync(ClientReport report);
}