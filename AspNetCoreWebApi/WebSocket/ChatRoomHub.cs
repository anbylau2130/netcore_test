using System.Security.Claims;
using AspNetCoreWebApi.Indentity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace AspNetCoreWebApi.WebSocket
{

    public class ChatRoomHub : Hub
    {
        private readonly UserManager<MyUser> userManager;

        public ChatRoomHub(UserManager<MyUser> userManager)
        {
            this.userManager = userManager;
        }



        /// <summary>
        /// 发送公共消息
        /// </summary>
        /// <param name="message">广播的消息</param>
        /// <returns></returns>
        public async Task SendPublicMessage(string message)
        {
            var claim = this.Context.User.FindFirst(ClaimTypes.Name);
            string connId = this.Context.ConnectionId;
            string msg = $"{connId}:{DateTime.Now}:{message}";
            //this.Clients.Caller //自己
            //this.Clients.Group()  //组
            //this.Clients.Others   //其他人
            //this.Clients.User(userid) //指定用户

            await this.Groups.AddToGroupAsync(this.Context.ConnectionId, "dev"); //指定用户加入到组
            await Clients.All.SendAsync("ReceivePublicMessage", msg);
        }




        /// <summary>
        /// 发送私有消息
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="message">发送的消息</param>
        /// <returns></returns>
        public async Task SendPrivateMessage(string username,string message)
        {
            var user=await userManager.FindByNameAsync(username);
            long userId = user.Id;
            string currentUserName = Context.UserIdentifier;
            await this.Clients.User(userId.ToString()).SendAsync("ReceivePrivateMessage", currentUserName,message);
        }


        //如果业务代码中需要使用hub推送消息
        //可以使用DI将 IHubContext注入到对应的Contorller中
        //
        /*
         private readonly IHubContext<ChatRoomHub> chatRoomHub;

         public *Controller(IHubContext<ChatRoomHub> chatRoomHub){
            this.chatRoomHub=chatRoomHub;
         }
         
         
         
         */


    }


}
