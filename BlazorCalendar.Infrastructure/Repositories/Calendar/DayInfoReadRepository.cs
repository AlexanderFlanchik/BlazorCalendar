using BlazorCalendar.Domain.Calendar;
using MongoDB.Driver;

namespace BlazorCalendar.Infrastructure.Repositories.Calendar
{
    public class DayInfoReadRepository(IMongoDatabase mongoDatabase) : IDayInfoReadRepository
    {
        private readonly IMongoCollection<DayInfo> _events = mongoDatabase.GetCollection<DayInfo>(typeof(DayInfo).Name);

        public async Task<IEnumerable<DayInfo>> GetDayEvents(string userId, int month, int year)
        {
            var minDate = new DateTime(year, month, 1).ToUniversalTime();
            var maxDate = new DateTime(year, month, DateTime.DaysInMonth(year, month), 23, 59, 59).ToUniversalTime();

            var dayFilter = new FilterDefinitionBuilder<DayInfo>()
                    .Where(d => d.UserId == userId && d.Timestamp >= minDate && d.Timestamp <= maxDate);

            var dayQuery = await _events.FindAsync(dayFilter);

            return await dayQuery.ToListAsync();
        }
    }
}