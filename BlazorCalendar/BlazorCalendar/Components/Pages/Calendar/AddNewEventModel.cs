using BlazorCalendar.DTOs;
using System.ComponentModel.DataAnnotations;

namespace BlazorCalendar.Components.Pages.Calendar
{
    public class AddOrEditEventModel: IValidatableObject
    {
        public string UserId { get; init; }
        public string? EventId { get; set; }
        public int Day { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public string? Title { get; set; } = default!;
        public string? Description { get; set; } = default!;
        public int Minutes { get; set; }
        public int Hours { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
        public IEnumerable<DayEvent>? DayEvents { get; set; }
        public DateTime Timestamp => new DateTime(Year, Month, Day, Hours, Minutes, 0);

        public AddOrEditEventModel(string userId)
        {
            UserId = userId;
        }

        public void SetTime(int hours, int minutes)
        {
            Hours = hours;
            Minutes = minutes;
        }

        public void Reset()
        {
            EventId = null;
            Description = null;
            Title = null;
            SetTime(0, 0);
            Errors.RemoveAll(e => true);
            DayEvents = null;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Title))
            {
                yield return new ValidationResult("Please enter an event title.");
            }
            
            if (string.IsNullOrEmpty(Description))
            {
                yield return new ValidationResult("Please enter an event description.");
            }

            if (DayEvents is not null)
            {
                var utcDate = Timestamp.ToUniversalTime();
                var eventExists = DayEvents.Any(
                        e => e.Timestamp.Hour == utcDate.Hour && 
                             e.Timestamp.Minute == utcDate.Minute && 
                             (EventId is null ? true : e.Id != EventId));

                if (eventExists)
                {
                    yield return new ValidationResult("This time has already been scheduled for other event.");
                }
            }
        }
    }
}