using BlazorCalendar.Application.Features.Calendar.Commands;
using BlazorCalendar.Shared.DTOs.Calendar;
using BlazorCalendar.Shared.UseCases.Calendar;
using MediatR;

namespace BlazorCalendar.UseCases.Calendar
{
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