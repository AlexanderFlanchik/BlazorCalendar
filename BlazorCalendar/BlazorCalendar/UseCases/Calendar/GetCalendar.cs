using BlazorCalendar.Application.Features.Calendar.Mappings;
using BlazorCalendar.Application.Features.Calendar.Queries;
using BlazorCalendar.Shared.DTOs.Calendar;
using BlazorCalendar.Shared.UseCases.Calendar;
using MediatR;

namespace BlazorCalendar.UseCases.Calendar
{
    public class GetCalendar(
        ISender sender, 
        CalendarResponseMapper mapper) : IGetCalendar
    {
        public async Task<CalendarModel> GetAsync(int year, int month, string userId)
        {
            var calendarData = await sender.Send(new CalendarRequest(month, year, userId));
            var res = mapper.Map(calendarData);
            return new CalendarModel(mapper.Map(calendarData));
        }
    }
}