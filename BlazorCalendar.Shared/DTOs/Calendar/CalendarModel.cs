namespace BlazorCalendar.Shared.DTOs.Calendar;

public record CalendarModel(CalendarResponseModel CurrentCalendar)
{
    /// <summary>
    /// Returns an empty calendar model with current month and year
    /// </summary>
    public static readonly CalendarModel Empty = new CalendarModel(
        new CalendarResponseModel()
    );
}
