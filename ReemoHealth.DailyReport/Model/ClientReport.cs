namespace ReemoHealth.DailyReport.Model;

public class ClientReport
{
    public DateTime Period { get; set; }
    public List<UserReport> UserReports { get; set; }
}