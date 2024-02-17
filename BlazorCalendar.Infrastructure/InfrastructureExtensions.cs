using BlazorCalendar.Domain.Calendar;
using BlazorCalendar.Domain.Identity;
using BlazorCalendar.Infrastructure.Repositories.Calendar;
using BlazorCalendar.Infrastructure.Repositories.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace BlazorCalendar.Infrastructure
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(sp => { 
                var mongoDbSettings = new MongoDbSettings();
                configuration.GetSection("MongoDbSettings").Bind(mongoDbSettings);

                var client = new MongoClient(mongoDbSettings.Host);
                var database = client.GetDatabase(mongoDbSettings.DatabaseName);

                return database;
            });

            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();

            services.AddScoped<IDayInfoReadRepository, DayInfoReadRepository>();
            services.AddScoped<IDayInfoWriteRepository, DayInfoWriteRepository>();

            return services;
        }
    }
}