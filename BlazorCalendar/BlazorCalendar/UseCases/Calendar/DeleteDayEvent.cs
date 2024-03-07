using BlazorCalendar.Application.Features.Calendar.Commands;
using BlazorCalendar.Shared.UseCases.Calendar;
using MediatR;

namespace BlazorCalendar.UseCases.Calendar
{
    public class DeleteDayEvent(ISender sender) : IDeleteDayEvent
    {
        public Task DeleteEvent(string eventId)
            => sender.Send(new DeleteDayEventCommand(eventId));
    }
}