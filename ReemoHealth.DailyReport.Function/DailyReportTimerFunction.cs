using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using DailyReport.Lifespark;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace ReemoHealth.DailyReport.Function;

public static class DailyReportTimerFunction
{
    [Function("DailyReportTimerFunction")]
    public static async Task Run([TimerTrigger("0 */5 * * * *")] MyInfo myTimer, FunctionContext context)
    {
        var logger = context.GetLogger("DailyReportTimerFunction");
        logger.LogInformation("C# Timer trigger function executed at: {DateTime.Now}", DateTime.Now);
        logger.LogInformation("Next timer schedule at: {myTimer.ScheduleStatus.Next}", myTimer.ScheduleStatus.Next);
        Guid lifesparkId = Guid.Parse(Environment.GetEnvironmentVariable("LifesparkId") ?? throw new InvalidOperationException("Must Specific Organization Id for Lifespark!"));
        var sqlConnString = Environment.GetEnvironmentVariable("SqlConnectionString");
        
        var lifesparkApiUrl = Environment.GetEnvironmentVariable("LifesparkApiUrl") ?? throw new InvalidOperationException("Must specify lifespark api url!");
        var lifesparkClientId = Environment.GetEnvironmentVariable("LifesparkClientId");
        var lifesparkClientSecret = Environment.GetEnvironmentVariable("LifesparkClientSecret");
        
        
        var lifesparkDataSender = new LifesparkDataSender(lifesparkApiUrl, lifesparkClientId, lifesparkClientSecret);
        
        var lifesparkDailyReportHandler = new DailyReportHandler(lifesparkId, lifesparkDataSender, sqlConnString);
        await lifesparkDailyReportHandler.Run(DateTime.Now);
        
        /*
         * Add any other clients we have here...
         */
        
        

    }
}

public class MyInfo
{
    public MyScheduleStatus ScheduleStatus { get; set; }

    public bool IsPastDue { get; set; }
}

public class MyScheduleStatus
{
    public DateTime Last { get; set; }

    public DateTime Next { get; set; }

    public DateTime LastUpdated { get; set; }
}