using BlazorCalendar.Client.Common;
using BlazorCalendar.Shared;
using BlazorCalendar.Shared.DTOs.Identity;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorCalendar.Common
{
    public class PersistingAuthenticationStateProvider : ServerAuthenticationStateProvider, IDisposable
    {
        private Task<AuthenticationState>? _authenticationStateTask;
        private readonly PersistentComponentState _state;
        private readonly PersistingComponentStateSubscription _subscription;

        public PersistingAuthenticationStateProvider(PersistentComponentState state)
        {
            _state = state;
            AuthenticationStateChanged += OnAuthenticationStateChanged;
            _subscription = _state.RegisterOnPersisting(OnPersistingAsync, RenderMode.InteractiveWebAssembly);
        }

        private async Task OnPersistingAsync()
        {
            if (_authenticationStateTask is null)
            {
                throw new InvalidOperationException("Authentication state has not been set.");
            }

            var authenticationState = await _authenticationStateTask;
            if (authenticationState?.User?.Identity?.IsAuthenticated != true)
            {
                return;
            }

            var userId = authenticationState.GetCurrentUserId();
            var userName = authenticationState.User?.Identity?.Name;

            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(userId))
            {
                var userInfo = new UserInfo(userId, userName);
                _state.PersistAsJson(Constants.UserInfoState, userInfo);
            }
        }

        private void OnAuthenticationStateChanged(Task<AuthenticationState> authenticationStateTask)
        {
            _authenticationStateTask = authenticationStateTask;
        }

        public void Dispose()
        {
            _authenticationStateTask?.Dispose();
            AuthenticationStateChanged -= OnAuthenticationStateChanged;
            _subscription.Dispose();
        }
    }
}
