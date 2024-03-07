using BlazorCalendar.Shared;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorCalendar.Client.Common
{
    public static class AuthenticationStateExtensions
    {
        public static string? GetCurrentUserId(this AuthenticationState state)
        {
            var userIdClaim = state.User.Claims.FirstOrDefault(c => c.Type == Constants.CustomClaims.UserId);
            if (userIdClaim is null)
            {
                return null;
            }

            return userIdClaim.Value;
        }
    }
}