using BlazorCalendar.Shared;
using BlazorCalendar.Shared.UseCases.Calendar;

namespace BlazorCalendar.Client.UseCases.Calendar
{
    public class DeleteDayEvent(IHttpClientFactory clientFactory) : IDeleteDayEvent
    {
        public async Task DeleteEvent(string eventId)
        {
            var client = clientFactory.CreateClient(Constants.CalendarApi);
            await client.DeleteAsync($"{client.BaseAddress}/{eventId}");
        }
    }
}