

using Microsoft.AspNetCore.Http.Connections;
using Whitelabel.Business;
using Whitelabel.Business.Services.SignalR;
using Whitelabel.Core.Settings;
using Whitelabel.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region AppSettings Configuration
            
builder.Services.Configure<AppSettings>(builder.Configuration);
var appSettings = builder.Configuration.GetSection(nameof(AppSettings)).Get<AppSettings>();
builder.Services.AddSingleton(appSettings!);
            
#endregion

builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddBusiness();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHub<WhiteLabelHub>("/whiteLabelHub", options =>
{
    options.Transports =
        HttpTransportType.WebSockets | 
        HttpTransportType.LongPolling;
    options.CloseOnAuthenticationExpiration = true;
    options.ApplicationMaxBufferSize = 65_536;
    options.TransportMaxBufferSize = 65_536;
    options.MinimumProtocolVersion = 0;
    options.TransportSendTimeout = TimeSpan.FromSeconds(10);
    options.WebSockets.CloseTimeout = TimeSpan.FromSeconds(3);
    options.LongPolling.PollTimeout = TimeSpan.FromSeconds(10);
});

app.Run();