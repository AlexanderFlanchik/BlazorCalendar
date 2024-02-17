using MediatR;

namespace BlazorCalendar.Application.Features.Calendar.Queries
{
    public record CalendarRequest(int Month, int Year, string UserId) : IRequest<CalendarResponse>;
}