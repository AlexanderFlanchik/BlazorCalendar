using BlazorCalendar.Application.DTOs;
using BlazorCalendar.Domain.Calendar;
using MediatR;
using Microsoft.Extensions.Options;

namespace BlazorCalendar.Application.Features.Calendar.Queries
{
    public class CalendarRequestHandler(
            IOptions<CalendarSettings> calendarSettingOptions, 
            IDayInfoReadRepository dayInfoRepository
        ) : IRequestHandler<CalendarRequest, CalendarResponse>
    {
        private readonly CalendarSettings calendarSettings = calendarSettingOptions.Value;
       
        public async Task<CalendarResponse> Handle(CalendarRequest request, CancellationToken cancellationToken)
        {
            var events = (await dayInfoRepository.GetDayEvents(request.UserId, request.Month, request.Year))
                .Select(e => new DayInfoResponse(e.Id, e.Timestamp, e.Title, e.Description))
                .ToList();

            var currentYear = DateTime.UtcNow.Year;

            var years = new List<int>();
            for (var y = calendarSettings.MinYear; y <= currentYear + 2; y++)
            {
                years.Add(y);
            }

            var months = GetMonthsList();
            var response = new CalendarResponse(events, months, years);

            return response;
        }

        private IList<MonthModel> GetMonthsList()
        {
            return new List<MonthModel>
            {
                new MonthModel(1, "January"),
                new MonthModel(2, "Feburary"),
                new MonthModel(3, "March"),
                new MonthModel(4, "April"),
                new MonthModel(5, "May"),
                new MonthModel(6, "June"),
                new MonthModel(7, "July"),
                new MonthModel(8, "August"),
                new MonthModel(9, "September"),
                new MonthModel(10, "October"),
                new MonthModel(11, "November"),
                new MonthModel(12, "December"),
            };
        }
    }
}