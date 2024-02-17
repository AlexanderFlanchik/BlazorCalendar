using BlazorCalendar.Application.Features.Identity.Queries;
using BlazorCalendar.Application.Features.User.Queries;
using MediatR;

namespace BlazorCalendar.UseCases.Identity
{
    public interface IGetUserInfo
    {
        Task<UserInfo?> GetAsync(string email, string password);
    }

    public class GetUserInfo(ISender sender) : IGetUserInfo
    {
        public async Task<UserInfo?> GetAsync(string email, string password)
              => await sender.Send(new CheckUserCredentialsRequest(email, password));
    }
}