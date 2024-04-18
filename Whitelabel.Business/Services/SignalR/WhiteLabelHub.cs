using Microsoft.AspNetCore.SignalR;

namespace Whitelabel.Business.Services.SignalR;

public class WhiteLabelHub : Hub<IWhiteLabelHubClient>
{
    public async Task BroadcastMessage()
    {
        await Clients.All.RefreshPage();
    }
}