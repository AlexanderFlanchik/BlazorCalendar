using BlazorCalendar.Application.Features.Calendar.Commands;
using MediatR;

namespace BlazorCalendar.UseCases.Calendar
{
    public interface IDeleteDayEvent
    {
        Task DeleteEvent(string eventId);
    }

    public class DeleteDayEvent(ISender sender) : IDeleteDayEvent
    {
        public Task DeleteEvent(string eventId)
            => sender.Send(new DeleteDayEventCommand(eventId));
    }
}