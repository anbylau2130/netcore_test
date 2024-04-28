using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace AspNetCoreWebApi.WebSocket
{

    public class ChatRoomHub : Hub
    {
        public Task SendPublicMessage(string message)
        {
            string connId = this.Context.ConnectionId;
            string msg = $"{connId}:{DateTime.Now}:{message}";
            return Clients.All.SendAsync("ReceivePublicMessage", msg);
        }
    }
}
