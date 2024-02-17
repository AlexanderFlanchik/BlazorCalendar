using BlazorCalendar.Domain.Identity;
using BlazorCalendar.Domain.User;
using MongoDB.Driver;

namespace BlazorCalendar.Infrastructure.Repositories.Identity
{
    public class UserWriteRepository: IUserWriteRepository
    {
        private readonly IMongoCollection<UserInfo> _users;

        public UserWriteRepository(IMongoDatabase database)
        {
            _users = database.GetCollection<UserInfo>(typeof(UserInfo).Name);
        }

        public async Task<UserInfo> CreateUser(string email, string firstName, string lastName, string passwordHash)
        {
            var newUser = new UserInfo
            {
                Id = string.Empty,
                Email = email,
                Name = new UserName
                {
                    FirstName = firstName,
                    LastName = lastName
                },
                PasswordHash = passwordHash
            };

            await _users.InsertOneAsync(newUser);

            return newUser;
        }
    }
}