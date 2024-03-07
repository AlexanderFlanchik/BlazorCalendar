using BlazorCalendar.Application.Features.Calendar.Commands;
using BlazorCalendar.Shared.DTOs.Calendar;
using BlazorCalendar.Shared.UseCases.Calendar;
using MediatR;

namespace BlazorCalendar.UseCases.Calendar
{
    public class AddDayEvent(ISender sender): IAddDayEvent
    {
        public async Task<ProcessDayEventResult> ProcessAsync(AddOrEditEventModel eventModel)
        {
            var addEventCommand = new AddDayEventCommand(
                    eventModel.UserId, 
                    eventModel.Timestamp.ToUniversalTime(), 
                    eventModel.Title!, 
                    eventModel.Description!);

            var response = await sender.Send(addEventCommand);

            return new ProcessDayEventResult { IsSuccess = true, EventId = response.Id };
        }
    }
}