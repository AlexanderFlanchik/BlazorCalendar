using BlazorCalendar.Domain.Identity;
using BlazorCalendar.Domain.User;
using MongoDB.Driver;

namespace BlazorCalendar.Infrastructure.Repositories.Identity
{
    public class UserReadRepository: IUserReadRepository
    {
        private readonly IMongoCollection<UserInfo> _users;

        public UserReadRepository(IMongoDatabase database)
        {
            _users = database.GetCollection<UserInfo>(typeof(UserInfo).Name);
        }

        public async Task<UserInfo?> GetUserById(string userId)
        {
            var query = await _users.FindAsync(new FilterDefinitionBuilder<UserInfo>().Where(u => u.Id == userId));

            return await query.FirstOrDefaultAsync();
        }

        public async Task<UserInfo?> GetUserByEmail(string email)
        {
            var query = await _users.FindAsync(new FilterDefinitionBuilder<UserInfo>().Where(u => u.Email == email));

            return await query.FirstOrDefaultAsync();
        }
    }
}