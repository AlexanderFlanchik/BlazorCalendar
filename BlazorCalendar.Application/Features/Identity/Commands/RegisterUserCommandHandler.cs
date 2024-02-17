using BlazorCalendar.Domain.Identity;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BlazorCalendar.Application.Features.Identity.Commands
{
    public class RegisterUserCommandHandler(
            IUserWriteRepository userWriteRepository, 
            IUserReadRepository userReadRepository,
            ILogger<RegisterUserCommandHandler> logger
        ) : IRequestHandler<RegisterUserCommand, RegisterUserResponse>
    {
        public async Task<RegisterUserResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await userReadRepository.GetUserByEmail(request.Email);
            if (existingUser is not null)
            {
                logger.LogInformation("Unable to register a customer. Email '{0}' is already in use.", request.Email);

                return RegisterUserResponse.Fail("Email already exists.");
            }

            var newUser = await userWriteRepository.CreateUser(
               request.Email, 
               request.FirstName, 
               request.LastName, 
               BCrypt.Net.BCrypt.HashPassword(request.Password));

            logger.LogInformation("New customer with has been registered successfully.");

            var response = RegisterUserResponse.Success(newUser.Id);

            return response;
        }
    }
}