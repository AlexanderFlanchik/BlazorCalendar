using BlazorCalendar.Client.Common;
using BlazorCalendar.Client.UseCases.Calendar;
using BlazorCalendar.Shared.Common;
using BlazorCalendar.Shared.UseCases.Calendar;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped<ITimeZoneService, TimeZoneService>();

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistingAuthenticationStateProvider>();

builder.Services.AddScoped<IGetCalendar, GetCalendar>();
builder.Services.AddScoped<IAddDayEvent, AddDayEvent>();
builder.Services.AddScoped<IDeleteDayEvent, DeleteDayEvent>();
builder.Services.AddScoped<IUpdateDayEvent, UpdateDayEvent>();

builder.Services.AddHttpClient("calendarApi", cfg => cfg.BaseAddress = new Uri($"{builder.HostEnvironment.BaseAddress}api/v1/calendar"));

await builder.Build().RunAsync();
