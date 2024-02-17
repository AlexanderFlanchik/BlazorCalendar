using BlazorCalendar.UseCases.Calendar;
using BlazorCalendar.UseCases.Identity;
using BlazorCalendar.Shared.Common;

namespace BlazorCalendar.Common
{
    public static class PresentationExtensions
    {
        public static IServiceCollection AddPresentationServices(this IServiceCollection services)
        {
            // Register app use cases here
            services.AddScoped<IGetCalendar, GetCalendar>();
            services.AddScoped<IGetUserInfo, GetUserInfo>();
            services.AddScoped<IRegisterUser, RegisterUser>();
            services.AddScoped<IAddDayEvent, AddDayEvent>();
            services.AddScoped<IUpdateDayEvent, UpdateDayEvent>();
            services.AddScoped<IDeleteDayEvent, DeleteDayEvent>();
            services.AddScoped<ITimeZoneService, TimeZoneService>();

            return services;
        }
    }
}