using BlazorCalendar.Components;
using BlazorCalendar.Application;
using Microsoft.AspNetCore.Authentication.Cookies;
using BlazorCalendar.Infrastructure;
using BlazorCalendar.Common;
using BlazorCalendar.Client.Components.Layout;
using BlazorCalendar.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(c => c.LoginPath = "/Login");

builder.Services.AddAuthorization();
builder.Services.AddHttpContextAccessor();
builder.Services.AddCascadingAuthenticationState();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddPresentationServices();

var app = builder.Build();

app.Use(async (ctx, next) => { 
    var path = ctx.Request.Path;
    var method = ctx.Request.Method;
    Console.WriteLine($"Request received: {path}, method: {method}");

    await next();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapCalendarEndpoints();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(NavMenu).Assembly);

app.Run();