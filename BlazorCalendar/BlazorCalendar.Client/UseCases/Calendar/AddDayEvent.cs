using BlazorCalendar.Shared;
using BlazorCalendar.Shared.DTOs.Calendar;
using BlazorCalendar.Shared.UseCases.Calendar;
using System.Net.Http.Json;

namespace BlazorCalendar.Client.UseCases.Calendar
{
    public class AddDayEvent(IHttpClientFactory clientFactory) : IAddDayEvent
    {
        public async Task<ProcessDayEventResult> ProcessAsync(AddOrEditEventModel eventModel)
        {
            var client = clientFactory.CreateClient(Constants.CalendarApi);
            var eventData = new EventData
            {
                UserId = eventModel.UserId,
                Title = eventModel.Title,
                Description = eventModel.Description,
                Timestamp = eventModel.Timestamp
            };
            
            var response = await client.PostAsJsonAsync(string.Empty, eventData);
            if (!response.IsSuccessStatusCode)
            {
                return new ProcessDayEventResult { IsSuccess = false, EventId = default };
            }

            var addedEvent = await response.Content.ReadFromJsonAsync<NewEventCreatedResponse>();

            return addedEvent is not null ? 
                new ProcessDayEventResult { IsSuccess = true, EventId = addedEvent.EventId } :
                new ProcessDayEventResult { IsSuccess = false, EventId = default };
        }
    }
}
