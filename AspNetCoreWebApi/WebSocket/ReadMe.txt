websocket

1.websocket基于TCP，支持二进制通信，双工通信
2.性能和并发能力更强
3.websocket独立于Http，不过一般还是把websocket部署在web服务器上，因为可以借助Http协议完成初始的握手，并且共享http的端口



SignalR

1.Asp.net core SignalR 是对.net core 下的websocket封装

2.Hub 就是数据交换中心。

Asp.net core中使用
1.创建类，继承自Hub
public class ChatRoomHub : Hub
{
    public Task SendPublicMessage(string message)
    {
        string connId = this.Context.ConnectionId;
        string msg = $"{connId}:{DateTime.Now}:{message}";
        return Clients.All.SendAsync("ReceivePublicMessage", msg);
    }
}
2.Program.cs
builder.Services.AddSignalR(); 
在app.MapControllers()之前调用
app.MapHub<CharRoomHub>("/Hubs/ChatRoom");
同时需要开启CORS



前台使用

yarn npm intall @microsoft/signalr

<script>
import { reactive, anMounted } from 'vue';
import * as signalR from '@microsoft/signalr',
let connection;
expart default fname: Login',
setup() { 

const state= reactive({userMessage: "", messages: [] ,token:""}),

const txtMsgOnkeypress = async function (e){
    if (e.keyCode != 13) 
    return;
    await connection.invoke("SendPublicMessage",state.userMessage); 
    state.userMessage = ""; 
};

onMounted(async function (){
    //{skipNegotiation:true,transport:signalR.HttpTransportType.WebSockets}选项可以使服务器不再进行协商直接发起websocket请求
    
    var options={skipNegotiation:true,transport:signalR.HttpTransportType.WebSockets};

    //设置身份验证
    options.accessTokenFactory=()=>state.token;
   
    connection= new signalR.HubConnectionBuilder()
    .withUrl('https://localhost:7112/Hubs/chatRcomHub',options)
    .withAutomaticReconnect().build();

    await connection.start();
    connection.on('ReceivePublicMessage', msg =>{
    state.messages.push(msgl)
    });

});

return {state,txtMsgOnkeypress };

}};
</script>



SignalR的分布式部署
1.四个客户端被连接到两台服务器上
2.解决方法：所有的服务器连接到同一个消息中间件。使用粘性回话或者调过协商
3.官方方案：Redis backplane
（1）install-package Microsoft.AspNetCore.SignalR.StackExchangeRedis
(2)builder.Services.AddSignalR().AddStackExchangeRedis("127.0.0.1",options=>{
options.Configuration.ChannelPrefix="Test_1";
})



SignalR身份认证
同样是[Authorize]对方法或类进行修饰
