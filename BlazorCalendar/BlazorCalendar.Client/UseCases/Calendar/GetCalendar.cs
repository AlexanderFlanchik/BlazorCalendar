using BlazorCalendar.Shared;
using BlazorCalendar.Shared.DTOs.Calendar;
using BlazorCalendar.Shared.UseCases.Calendar;
using System.Net.Http.Json;

namespace BlazorCalendar.Client.UseCases.Calendar
{
    public class GetCalendar(IHttpClientFactory httpClientFactory) : IGetCalendar
    {
        public async Task<CalendarModel> GetAsync(int year, int month, string userId)
        {
            var client = httpClientFactory.CreateClient(Constants.CalendarApi);
            var calendarResponse = await client.GetFromJsonAsync<CalendarModel>($"?userId={userId}&year={year}&month={month}");

            return calendarResponse!;
        }
    }
}