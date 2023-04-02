using Asp_NET_Core_6_Template.Attributes;
using Common.Extensions;
using Microsoft.AspNetCore.SignalR;

namespace Asp_NET_Core_6_Template.Hubs.Implementation
{
    [Authorize]
    public class RoomHub : BaseHub
    {

       /* public async Task send(string text)
        {
            await Clients.All.SendAsync("receive", "salut " + Context.GetUser());
        }*/
        public async Task JoinGroup(string roomName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
            await Clients.Group(roomName).SendAsync("receiveMessage", new { author = Context.GetUser(), message = Context.GetUser() + " joined." });
        }

        public async Task SendMessage(string roomName,string message)
        {
            await Clients.Group(roomName).SendAsync("receiveMessage", new { author = Context.GetUser(), message = message });
        }

    }
}
