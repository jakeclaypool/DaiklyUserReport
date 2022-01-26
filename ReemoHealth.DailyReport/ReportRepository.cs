using System.Data.SqlClient;
using ReemoHealth.DailyReport.Interfaces;
using ReemoHealth.DailyReport.Model;

namespace ReemoHealth.DailyReport;

public class ReportRepository: IReportRepository
{

    private SqlConnection conn;
    public ReportRepository(SqlConnection conn)
    {
        this.conn = conn;
    }
    
    public void Dispose()
    {
        conn.Dispose();
    }

    public Task<List<UserReport>> GetUserReports(Guid organizationId, DateTime period)
    {
        throw new NotImplementedException();
    }
}