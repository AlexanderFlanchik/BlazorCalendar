namespace BlazorCalendar.Shared.UseCases.Calendar
{
    public interface IDeleteDayEvent
    {
        Task DeleteEvent(string eventId);
    }
}