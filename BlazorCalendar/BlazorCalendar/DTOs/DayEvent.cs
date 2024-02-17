namespace BlazorCalendar.DTOs
{
    public class DayEvent
    {
        public string Id { get; set; } = default!;
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime Timestamp { get; set; }
    }
}