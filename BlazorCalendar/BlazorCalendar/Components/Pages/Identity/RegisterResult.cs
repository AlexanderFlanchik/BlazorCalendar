namespace BlazorCalendar.Components.Pages.Identity
{
    public class RegisterResult
    {
        public string? UserId { get; set; }
        public string? Error { get; set; }

        public bool IsSuccess => string.IsNullOrEmpty(Error);
    }
}