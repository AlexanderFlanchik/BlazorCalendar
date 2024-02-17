namespace BlazorCalendar.Application.Features.Calendar.Queries
{
    public record DayInfoResponse(
        string Id,
        DateTime Timestamp,
        string Title,
        string? Description
    );
}