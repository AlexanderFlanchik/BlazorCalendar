using BlazorCalendar.Application.Features.Calendar.Queries;

namespace BlazorCalendar.DTOs;

public record CalendarModel(CalendarResponse CurrentCalendar)
{
    /// <summary>
    /// Returns an empty calendar model with current month and year
    /// </summary>
    public static readonly CalendarModel Empty = new CalendarModel(
        new CalendarResponse(new List<DayInfoResponse>(), new List<MonthModel>(), new List<int>())
    );

    public IList<DayEvent> GetDayEvents() => 
        CurrentCalendar.Days.Select((d) =>
            new DayEvent
            {
                Id = d.Id,
                Title = d.Title,
                Description = d.Description!,
                Timestamp = d.Timestamp
            }
        ).ToList();
}
