using BlazorCalendar.Application.Features.Calendar.Commands;
using BlazorCalendar.Components.Pages.Calendar;
using BlazorCalendar.DTOs;
using MediatR;

namespace BlazorCalendar.UseCases.Calendar
{
    public interface IUpdateDayEvent: IDayEventProcessor;

    public class UpdateDayEvent(ISender sender) : IUpdateDayEvent
    {
        public async Task<ProcessDayEventResult> ProcessAsync(AddOrEditEventModel eventModel)
        {
            var eventId = eventModel.EventId!;
            await sender.Send(
                new UpdateDayEventCommand(
                    eventId, 
                    eventModel.Title!, 
                    eventModel.Description!, 
                    eventModel.Timestamp.ToUniversalTime())
                );

            return new ProcessDayEventResult { EventId = eventId, IsSuccess = true };
        }
    }
}