using System.ComponentModel.DataAnnotations;

namespace BlazorCalendar.Shared.DTOs.Calendar
{
    public class EventData
    {
        [Required]
        public string UserId { get; set; } = default!;
        public string? Description { get; set; }
        public string? Title { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
