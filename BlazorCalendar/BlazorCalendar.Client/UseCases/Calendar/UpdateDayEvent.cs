using BlazorCalendar.Shared;
using BlazorCalendar.Shared.DTOs.Calendar;
using BlazorCalendar.Shared.UseCases.Calendar;
using System.Net.Http.Json;

namespace BlazorCalendar.Client.UseCases.Calendar
{
    public class UpdateDayEvent(IHttpClientFactory clientFactory) : IUpdateDayEvent
    {
        public async Task<ProcessDayEventResult> ProcessAsync(AddOrEditEventModel eventModel)
        {
            var client = clientFactory.CreateClient(Constants.CalendarApi);
            var eventData = new EventData 
                { 
                    UserId = eventModel.UserId, 
                    Title = eventModel.Title, 
                    Description = eventModel.Description, 
                    Timestamp = eventModel.Timestamp,
                };

            var response = await client.PutAsJsonAsync($"{client.BaseAddress}/{eventModel.EventId}", eventData);
            
            return new ProcessDayEventResult() 
                { 
                    IsSuccess = response.IsSuccessStatusCode, 
                    EventId = eventModel.EventId 
                };
        }
    }
}
