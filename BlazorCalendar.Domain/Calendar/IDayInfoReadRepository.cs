namespace BlazorCalendar.Domain.Calendar
{
    public interface IDayInfoReadRepository
    {
        /// <summary>
        /// Returns customer's day events during the month and year specified.
        /// </summary>
        /// <param name="userId">Customer ID</param>
        /// <param name="month">Month number</param>
        /// <param name="year">Year</param>
        /// <returns></returns>
        Task<IEnumerable<DayInfo>> GetDayEvents(string userId, int month, int year);
    }
}