namespace ReemoHealth.DailyReport.Model;

public class UserReport
{
    public string ExternalId { get; set; }
    public int Steps { get; set; }
    public int LowestHeartRate { get; set; }
    public int HighestHeartRate { get; set; }
    public int MedianHeartRate { get; set; }
    public int AverageHeartRate { get; set; }
    public List<Message> Messages { get; set; } = new List<Message>();
    public List<Call> Calls { get; set; } = new List<Call>();
}