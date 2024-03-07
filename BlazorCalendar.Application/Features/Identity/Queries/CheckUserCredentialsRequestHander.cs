using BlazorCalendar.Domain.Identity;
using BlazorCalendar.Shared.DTOs.Identity;
using MediatR;

namespace BlazorCalendar.Application.Features.User.Queries
{
    public class CheckUserCredentialsRequestHander(IUserReadRepository userRepository) : IRequestHandler<CheckUserCredentialsRequest, UserInfo?>
    {
        public async Task<UserInfo?> Handle(CheckUserCredentialsRequest request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetUserByEmail(request.Email);
            if (user is null)
            {
                return null;
            }

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return null;
            }

            return new UserInfo(user.Id, user.GetFullName());
        }
    }
}