using BlazorCalendar.Application.Features.Calendar.Queries;
using BlazorCalendar.DTOs;
using BlazorCalendar.Shared.Common;
using MediatR;

namespace BlazorCalendar.UseCases.Calendar
{
    public interface IGetCalendar
    {
        Task<CalendarModel> GetAsync(int year, int month, string userId);
    }

    public class GetCalendar(ISender sender) : IGetCalendar
    {
        public async Task<CalendarModel> GetAsync(int year, int month, string userId)
        {
            var calendarData = await sender.Send(new CalendarRequest(month, year, userId));

            return new CalendarModel(calendarData);
        }
    }
}