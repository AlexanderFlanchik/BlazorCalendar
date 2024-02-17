using BlazorCalendar.Domain.User;

namespace BlazorCalendar.Domain.Identity
{
    public interface IUserReadRepository
    {
        /// <summary>
        /// Returns a user instance by user Id.
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns></returns>
        Task<UserInfo?> GetUserById(string userId);

        /// <summary>
        /// Returns a user instance by email.
        /// </summary>
        /// <param name="email">User email</param>
        /// <returns></returns>
        Task<UserInfo?> GetUserByEmail(string email);
    }
}