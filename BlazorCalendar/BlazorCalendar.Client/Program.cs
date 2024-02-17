using BlazorCalendar.Client.Common;
using BlazorCalendar.Shared.Common;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped<ITimeZoneService, TimeZoneService>();

await builder.Build().RunAsync();
