using BlazorCalendar.Domain.Calendar;
using MediatR;

namespace BlazorCalendar.Application.Features.Calendar.Commands
{
    public class AddDayEventCommandHandler(IDayInfoWriteRepository dayInfoRepository) : IRequestHandler<AddDayEventCommand, AddDayEventResponse>
    {
        public async Task<AddDayEventResponse> Handle(AddDayEventCommand request, CancellationToken cancellationToken)
        {
            var dayEvent = await dayInfoRepository.AddDayEvent(
                    request.UserId, 
                    request.Timestamp, 
                    request.Title, 
                    request.Description);

            return new AddDayEventResponse(dayEvent.Id, dayEvent.Timestamp, dayEvent.Description);
        }
    }
}