

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

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<WhiteLabelHub>("/whiteLabelHub");
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});



app.Run();