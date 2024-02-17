using BlazorCalendar.Domain.User;

namespace BlazorCalendar.Domain.Calendar
{
    public class DayInfo: EntityBase
    {
        public DateTime Timestamp { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public required string UserId { get; set; }

        // Navigation property
        public UserInfo? User { get; set; }
    }
}