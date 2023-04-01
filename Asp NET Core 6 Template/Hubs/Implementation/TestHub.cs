using Asp_NET_Core_6_Template.Attributes;
using Common.Extensions;
using Microsoft.AspNetCore.SignalR;

namespace Asp_NET_Core_6_Template.Hubs.Implementation
{
    [Authorize]
    public class TestHub : BaseHub
    {
        public async Task send(string text)
        {
            await Clients.All.SendAsync("receive", "salut " + Context.GetUser());
        }
    }
}
