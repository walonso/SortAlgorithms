using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace WebSortAlgorithms
{
    public class ClientHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
