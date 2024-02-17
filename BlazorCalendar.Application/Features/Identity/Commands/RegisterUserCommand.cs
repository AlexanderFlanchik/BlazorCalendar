using MediatR;

namespace BlazorCalendar.Application.Features.Identity.Commands
{
    public record RegisterUserCommand(
        string FirstName,
        string LastName,
        string Email,
        string Password
     ): IRequest<RegisterUserResponse>;
}