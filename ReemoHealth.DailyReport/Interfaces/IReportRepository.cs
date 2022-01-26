using ReemoHealth.DailyReport.Model;

namespace ReemoHealth.DailyReport.Interfaces;

public interface IReportRepository: IDisposable
{
    Task<List<UserReport>> GetUserReports(Guid organizationId, DateTime period);
}