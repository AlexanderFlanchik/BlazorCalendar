using BlazorCalendar.Domain.Calendar;
using MediatR;

namespace BlazorCalendar.Application.Features.Calendar.Commands
{
    public class UpdateDayEventCommandHandler(IDayInfoWriteRepository dayInfoWriteRepository) : IRequestHandler<UpdateDayEventCommand>
    {
        public Task Handle(UpdateDayEventCommand request, CancellationToken cancellationToken)
            => dayInfoWriteRepository.UpdateDayEvent(
                    request.EventId, 
                    request.Timestamp, 
                    request.Title, 
                    request.Description);
    }
}