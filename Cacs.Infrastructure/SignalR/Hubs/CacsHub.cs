using Microsoft.AspNetCore.SignalR;

namespace Cacs.Infrastructure.SignalR.Hubs;

public class CacsHub : Hub
{
    public async Task UpdateCategory(string name, int value)
    {
        await Clients.All.SendAsync(
            "CategoryUpdated",
            name,
            value);
    }
}
