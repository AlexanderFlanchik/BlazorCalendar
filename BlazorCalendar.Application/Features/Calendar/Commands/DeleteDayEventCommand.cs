using MediatR;

namespace BlazorCalendar.Application.Features.Calendar.Commands;

public record DeleteDayEventCommand(string EventId): IRequest;
