using BlazorCalendar.Application.DTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorCalendar.Application
{
    public static class ApplicationExtensions
    {
        /// <summary>
        /// Adds application services to service collection
        /// </summary>
        /// <param name="services">A service collection</param>
        /// <param name="configuration">The app config</param>
        /// <returns>A service collection</returns>
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CalendarSettings>(cfg =>
            {
                var calendarSettings = new CalendarSettings();
                configuration.GetSection("CalendarSettings").Bind(calendarSettings);
                cfg.MinYear = calendarSettings.MinYear;
            });

            services.AddMediatR(config => {
                config.RegisterServicesFromAssembly(typeof(AppMarker).Assembly);
            });

            return services;
        }
    }
}