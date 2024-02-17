using BlazorCalendar.Domain.User;

namespace BlazorCalendar.Domain.Identity
{
    public interface IUserWriteRepository
    {
        /// <summary>
        /// Creates a new user using the user data provided.
        /// </summary>
        /// <param name="email">User email</param>
        /// <param name="firstName">First name</param>
        /// <param name="lastName">Last name</param>
        /// <param name="password">Password (encrypted)</param>
        /// <returns></returns>
        Task<UserInfo> CreateUser(string email, string firstName, string lastName, string password);
    }
}