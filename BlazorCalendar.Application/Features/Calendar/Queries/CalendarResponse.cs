using BlazorCalendar.Shared.DTOs.Calendar;

namespace BlazorCalendar.Application.Features.Calendar.Queries
{
    public class CalendarResponse
    {
        /// <summary>
        /// Gets customer events
        /// </summary>
        public IList<DayInfoResponse> Days { get; } = new List<DayInfoResponse>();

        // For dropdowns
        public IList<MonthModel> Months { get; } = new List<MonthModel>();
        public IList<int> Years { get; } = new List<int>();

        public CalendarResponse(
            IList<DayInfoResponse> days, 
            IList<MonthModel> months, 
            IList<int> years)
        {
            Days = days;
            Months = months;
            Years = years;
        }
    }
}