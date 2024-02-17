namespace BlazorCalendar.Domain.Calendar
{
    public interface IDayInfoWriteRepository
    {
        /// <summary>
        /// Persists and returns new day event.
        /// </summary>
        /// <param name="userId">Customer ID</param>
        /// <param name="timeStamp">Event timestamp</param>
        /// <param name="description">Event description</param>
        /// <returns></returns>
        Task<DayInfo> AddDayEvent(string userId, DateTime timeStamp, string title, string description);

        /// <summary>
        /// Updates existing day event.
        /// </summary>
        /// <param name="eventId">Event ID</param>
        /// <param name="timeStamp">Event timestamp</param>
        /// <param name="description">Event description</param>
        /// <returns></returns>
        Task UpdateDayEvent(string eventId, DateTime timeStamp, string title, string description);

        /// <summary>
        /// Deletes a day event
        /// </summary>
        /// <param name="eventId">Event ID</param>
        /// <returns></returns>
        Task DeleteDayEvent(string eventId);
    }
}