using System.Text;
using System.Threading.Channels;
using AspNetCoreWebApi.JWT;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace AspNetCoreWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RabbitMQController : ControllerBase
    {

        [NotCheckJwtVersion]
        [HttpGet]
        public void SendMQ()
        {
            var connFactory = new ConnectionFactory();
            connFactory.HostName = "localhost";
            connFactory.DispatchConsumersAsync = true;
            var conn = connFactory.CreateConnection();
            //交换机名称
            string exchangeName = "ExChange";
            string routingKey = "Event";
            while (true)
            {
                using var channel = conn.CreateModel();
                var prop = channel.CreateBasicProperties();
                //持久化
                prop.DeliveryMode = 2;
                //声明交换机
                channel.ExchangeDeclare(exchangeName, "direct");
                //要发送的消息
                byte[] buffer = Encoding.UTF8.GetBytes(DateTime.Now.ToString());
                channel.BasicPublish(exchangeName, routingKey, mandatory: true, basicProperties: prop, body: buffer);
                Console.WriteLine("消息已发送：" + DateTime.Now.ToString());
                Thread.Sleep(5000);
            }
        }

        [NotCheckJwtVersion]
        [HttpGet]
        public void ReceiveMQ()
        {
            var connFactory = new ConnectionFactory();
            connFactory.HostName = "localhost";
            connFactory.DispatchConsumersAsync = true;
            var conn = connFactory.CreateConnection();
            string exchangeName = "ExChange";
            string queueName = "Queue";
            string routingKey = "Event";
            IModel channel = conn.CreateModel();
            {
                //声明交换机
                channel.ExchangeDeclare(exchangeName, "direct");
                //声明队列
                channel.QueueDeclare(queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
                //绑定队列
                channel.QueueBind(queueName, exchange: exchangeName, routingKey: routingKey);

                //声明消费者
                AsyncEventingBasicConsumer consumer = new AsyncEventingBasicConsumer(channel);
                consumer.Received += Consumer_Received;
                channel.BasicConsume(queueName, autoAck: false, consumer: consumer);

                async Task Consumer_Received(object sender, BasicDeliverEventArgs args)
                {
                    try
                    {
                        var bytes = args.Body.ToArray();
                        string msg = Encoding.UTF8.GetString(bytes);
                        Console.WriteLine(DateTime.Now + "收到消息了" + msg);
                        channel.BasicAck(args.DeliveryTag, multiple: false);
                        await Task.Delay(1000);

                    }
                    catch (Exception ex)
                    {
                        channel.BasicReject(args.DeliveryTag, true);
                        Console.WriteLine($"异常信息：{ex.Message}");

                    }
                }
            }
                
        }

    }
}
