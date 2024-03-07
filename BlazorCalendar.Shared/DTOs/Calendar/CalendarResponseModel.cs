namespace BlazorCalendar.Shared.DTOs.Calendar
{
    public class CalendarResponseModel
    {
        public IList<DayEvent> DayEvents { get; set; } = new List<DayEvent>();
        public IList<MonthModel> Months { get; set; } = new List<MonthModel>();
        public IList<int> Years { get; set; } = new List<int>();
    }
}
