using Microsoft.AspNetCore.SignalR;
using Restaurant.Models;

namespace Restaurant.Hubs
{
    public class OrderHub:Hub
    {
        private static Dictionary<int,string> users=new Dictionary<int,string>();
        private static List<Order> orders = new List<Order>();
        public override Task OnConnectedAsync()
        {
            var id =Convert.ToInt16(Context.GetHttpContext().Request.Query["Uid"]);
            users[id] = Context.ConnectionId;
            return base.OnConnectedAsync();
        }
        public async Task createOrder(string name,int uid,int ownerId)
        {
            var random = new Random();
            var data = new Order() { Id = random.Next(100), FoodItemName = name, IsOrderAccepted = false,Uid=uid};
            orders.Add(data);
            await Clients.Client(users[uid]).SendAsync("create",data);
            await Clients.Client(users[ownerId]).SendAsync("create",data);
        }
        public async Task AcceptOrder(int uid,int oId)
        {
           var ordertoAccept=orders.Find(obj => obj.Id == oId);
            ordertoAccept.IsOrderAccepted = true;
            await Clients.Client(users[uid]).SendAsync("accept", ordertoAccept);
        }
        public async Task RejectOrder( int uid, int oId)
        {
            var ordertoAccept = orders.Find(obj => obj.Id == oId);
            ordertoAccept.IsOrderAccepted = false;
            await Clients.Client(users[uid]).SendAsync("rejected", ordertoAccept);
        }
    }
}
