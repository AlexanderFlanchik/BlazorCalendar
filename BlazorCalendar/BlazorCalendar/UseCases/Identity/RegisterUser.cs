using BlazorCalendar.Application.Features.Identity.Commands;
using BlazorCalendar.Components.Pages.Identity;
using MediatR;

namespace BlazorCalendar.UseCases.Identity
{
    public interface IRegisterUser
    {
        Task<RegisterResult> ProcessAsync(RegisterModel registerModel);
    }

    public class RegisterUser(ISender sender): IRegisterUser
    {
        public async Task<RegisterResult> ProcessAsync(RegisterModel registerModel)
        {
            var registerUser = new RegisterUserCommand(
                 registerModel.FirstName,
                 registerModel.LastName,
                 registerModel.Email,
                 registerModel.Password);

            var response = await sender.Send(registerUser);

            var result = new RegisterResult()
            {
                UserId = response.UserId,
                Error = response.Error
            };

            return result;
        }
    }
}