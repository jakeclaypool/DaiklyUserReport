using System.Data;
using System.Data.SqlClient;
using ReemoHealth.DailyReport.Interfaces;
using ReemoHealth.DailyReport.Model;

namespace ReemoHealth.DailyReport;

public class DailyReportHandler: IDisposable
{
    private Guid _distributionChannelId { get; set; }
    private IDataSender _dataSender { get; set; }
    private IReportRepository _repository { get; set; }
    public DailyReportHandler(Guid distributionChannelId, IDataSender dataSender, string sqlConnectionString)
    {
        this._repository = new ReportRepository(new SqlConnection(sqlConnectionString));
        this._distributionChannelId = distributionChannelId;
        this._dataSender = dataSender;
    }
    

    public async Task Run(DateTime period)
    {
        await _dataSender.InitializeAsync();
        var userReports = await this._repository.GetUserReports(this._distributionChannelId, period);
        var report = new ClientReport
        {
            Period = period,
            UserReports = userReports
        };
        try
        {
            await this._dataSender.SendDataAsync(report);
        }
        catch (Exception e)
        {
            // TODO: Add error handling and retry logic
            Console.WriteLine(e);
            throw;
        }
        
    }

    public void Dispose()
    {
        _dataSender.Dispose();
        this._repository.Dispose();
    }
}