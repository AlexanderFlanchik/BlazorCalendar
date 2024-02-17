using BlazorCalendar.Shared.Common;
using Microsoft.JSInterop;

namespace BlazorCalendar.Client.Common
{
    public class TimeZoneService : ITimeZoneService
    {
        private readonly IJSRuntime jsRuntime;

        public TimeZoneService(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
        }

        public async Task<TimeSpan> GetClientOffsetAsync()
        {
            var offsetMinutes = await jsRuntime.InvokeAsync<int>("_getClientTimezoneOffset");

            return TimeSpan.FromMinutes(offsetMinutes);
        }
    }
}