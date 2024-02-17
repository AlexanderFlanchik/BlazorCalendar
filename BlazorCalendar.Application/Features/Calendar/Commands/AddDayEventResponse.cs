namespace BlazorCalendar.Application.Features.Calendar.Commands
{
    public record AddDayEventResponse(string Id, DateTime Timestamp,
        string Description);
}
