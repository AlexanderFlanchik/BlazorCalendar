using BlazorCalendar.Shared.DTOs.Calendar;

namespace BlazorCalendar.Shared.UseCases.Calendar
{
    public interface IGetCalendar
    {
        Task<CalendarModel> GetAsync(int year, int month, string userId);
    }
}