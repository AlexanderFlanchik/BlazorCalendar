namespace BlazorCalendar.Shared.Common
{
    public interface ITimeZoneService
    {
        Task<TimeSpan> GetClientOffsetAsync();
    }
}
