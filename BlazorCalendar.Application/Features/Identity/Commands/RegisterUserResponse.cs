namespace BlazorCalendar.Application.Features.Identity.Commands;

public class RegisterUserResponse
{
    public string? UserId { get; init; }
    public string? Error { get; init; }

    private RegisterUserResponse() { }

    public static RegisterUserResponse Success(string userId)
    {
        return new RegisterUserResponse { UserId = userId };
    }

    public static RegisterUserResponse Fail(string error) 
    { 
        return new RegisterUserResponse {  Error = error }; 
    }
}