namespace ReemoHealth.DailyReport.Model;

public class OrganizationReport
{
    public DateTime ReportTime { get; set; }
    public List<UserReport> UserReports { get; set; }
}