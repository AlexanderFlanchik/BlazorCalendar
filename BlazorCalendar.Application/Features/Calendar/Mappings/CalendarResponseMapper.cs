using BlazorCalendar.Application.Features.Calendar.Queries;
using BlazorCalendar.Shared.DTOs.Calendar;

namespace BlazorCalendar.Application.Features.Calendar.Mappings
{
    public class CalendarResponseMapper
    {
        public CalendarResponseModel Map(CalendarResponse response)
        {
            return new CalendarResponseModel()
            {
                DayEvents = response.Days.Select(d => 
                            new DayEvent 
                            { 
                                Id = d.Id, 
                                Description = d.Description ?? string.Empty, 
                                Timestamp = d.Timestamp, 
                                Title = d.Title 
                            }
                     ).ToList(),
                Months = response.Months,
                Years = response.Years
            };
        }
    }
}