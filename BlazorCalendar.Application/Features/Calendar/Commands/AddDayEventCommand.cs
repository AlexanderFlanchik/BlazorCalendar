using MediatR;

namespace BlazorCalendar.Application.Features.Calendar.Commands
{
    public record AddDayEventCommand(string UserId, DateTime Timestamp, string Title, string Description)
        : IRequest<AddDayEventResponse>;
}
