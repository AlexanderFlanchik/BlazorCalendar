using BlazorCalendar.Components.Pages.Calendar;
using BlazorCalendar.DTOs;

namespace BlazorCalendar.UseCases.Calendar;

public interface IDayEventProcessor
{
    /// <summary>
    /// Represents an action which is triggered when a day event is being created or updated.
    /// </summary>
    /// <param name="eventModel">AddOrEditEventModel context</param>
    /// <returns></returns>
    Task<ProcessDayEventResult> ProcessAsync(AddOrEditEventModel eventModel);
}