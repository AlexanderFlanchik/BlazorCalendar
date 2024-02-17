using MediatR;

namespace BlazorCalendar.Application.Features.Calendar.Commands;

public record UpdateDayEventCommand(
    string EventId, 
    string Title, 
    string Description, 
    DateTime Timestamp): IRequest;
