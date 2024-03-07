using BlazorCalendar.Shared;
using BlazorCalendar.Shared.Common;

namespace BlazorCalendar.Common
{
    public class TimeZoneService(IHttpContextAccessor httpContextAccessor) : ITimeZoneService
    {
        private TimeSpan _offset = TimeSpan.FromMinutes(0);

        public Task<TimeSpan> GetClientOffsetAsync()
        {
            var context = httpContextAccessor.HttpContext;
            if (context is not null && context.Request.Cookies.TryGetValue(Constants.TimeZoneOffset, out var offsetCookie)
                    && int.TryParse(offsetCookie, out var offSetMinutes)
                )
            {
                _offset = TimeSpan.FromMinutes(offSetMinutes);
            }
            return Task.FromResult(_offset);
        }
    }
}