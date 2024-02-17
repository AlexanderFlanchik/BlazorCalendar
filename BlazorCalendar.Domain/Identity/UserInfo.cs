namespace BlazorCalendar.Domain.User
{
    public class UserInfo: EntityBase
    {
        public UserName Name { get; set; } = new UserName();
        public string PasswordHash { get; set; } = null!;
        public string? Email { get; set; }

        public string GetFullName() => $"{Name.FirstName} {Name.LastName}";
    }
}