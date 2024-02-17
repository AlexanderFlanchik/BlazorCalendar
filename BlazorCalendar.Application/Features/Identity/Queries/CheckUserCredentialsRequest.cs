using BlazorCalendar.Application.Features.Identity.Queries;
using MediatR;

namespace BlazorCalendar.Application.Features.User.Queries;

public record CheckUserCredentialsRequest(string Email, string Password) : IRequest<UserInfo>;