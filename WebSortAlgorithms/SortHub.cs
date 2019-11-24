using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace WebSortAlgorithms
{
    public class SortHub : Hub<ISortHubClient>
    {
        public override Task OnConnectedAsync()
        {
            string userName = Context.User.Identity.Name;
            string connectionId = Context.ConnectionId;

            //var user = Users.GetOrAdd(userName, _ => new User
            //{
            //    Name = userName,
            //    ConnectionIds = new HashSet<string>()
            //});

            //lock (user.ConnectionIds)
            //{

            //    user.ConnectionIds.Add(connectionId);

            //    // TODO: Broadcast the connected user
            //}


            //Clients.Client(connectionId).Welcome("hello");
            return base.OnConnectedAsync();
        }
        
        public override Task OnDisconnectedAsync(Exception exception)
        {
            string userName = Context.User.Identity.Name;
            string connectionId = Context.ConnectionId;

            //User user;
            //Users.TryGetValue(userName, out user);

            //if (user != null)
            //{

            //    lock (user.ConnectionIds)
            //    {

            //        user.ConnectionIds.RemoveWhere(cid => cid.Equals(connectionId));

            //        if (!user.ConnectionIds.Any())
            //        {

            //            User removedUser;
            //            Users.TryRemove(userName, out removedUser);

            //            // You might want to only broadcast this info if this 
            //            // is the last connection of the user and the user actual is 
            //            // now disconnected from all connections.
            //            Clients.Others.userDisconnected(userName);
            //        }
            //    }
            //}

            return base.OnDisconnectedAsync(exception);
        }       
    }
}
