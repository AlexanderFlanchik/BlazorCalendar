using BlazorCalendar.Shared.DTOs.Identity;
using MediatR;

namespace BlazorCalendar.Application.Features.User.Queries;

public record CheckUserCredentialsRequest(string Email, string Password) : IRequest<UserInfo>;