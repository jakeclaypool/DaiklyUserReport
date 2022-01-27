using ReemoHealth.DailyReport.Interfaces;
using ReemoHealth.DailyReport.Model;

namespace DailyReport.Lifespark;

public class LifesparkDataSender: IDataSender
{

    public LifesparkDataSender(string apiUrl, string apiClientId, string apiClientSecret)
    {
        // TODO set those to values or change if we determine we need different type of API key
    }
    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public Task InitializeAsync()
    {
        throw new NotImplementedException();
    }

    public Task SendDataAsync(ClientReport report)
    {
        throw new NotImplementedException();
    }
    
    
}