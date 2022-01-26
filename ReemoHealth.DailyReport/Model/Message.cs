namespace ReemoHealth.DailyReport.Model;

public class Message
{
    public Guid Id { get; set; }
    public Guid ExternalId { get; set; }
    public Guid MessageContentId { get; set; }
    public string MessageText { get; set; }
    public string ResponseType { get; set; }
    public string Response { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime ReceivedTime { get; set; }
    public DateTime FirstViewedTime { get; set; }
    public DateTime LastViewedTime { get; set; }
    public DateTime RespondedTime { get; set; }
    public string ExpirationTime { get; set; }
    public string WearerUtcOffsetSeconds { get; set; }
}