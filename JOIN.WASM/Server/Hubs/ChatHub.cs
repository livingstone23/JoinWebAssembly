using JOIN.WASM.Shared.Models;
using Microsoft.AspNetCore.SignalR;

namespace JOIN.WASM.Server.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(Message message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
