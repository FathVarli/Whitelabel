using Microsoft.AspNetCore.SignalR;

namespace Whitelabel.Business.Services.SignalR;

public class WhiteLabelHub : Hub
{
    public async Task RefreshPage()
    {
        await Clients.All.SendAsync("RefreshPage");
    }
}