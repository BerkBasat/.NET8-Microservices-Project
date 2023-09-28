using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Ecommerce.Services.ShoppingCartAPI.RabbitMQSender
{
    public class RabbitMQCartMessageSender : IRabbitMQCartMessageSender
    {
        private readonly string _hostName;
        private readonly string _userName;
        private readonly string _password;
        private IConnection _connection;

        public RabbitMQCartMessageSender()
        {
            _hostName = "localhost";
            _userName = "guest";
            _password = "guest";
        }

        public void SendMessage(object message, string queueName)
        {
            if(ConnectionExists())
            {
                //create channel
                using var channel = _connection.CreateModel();
                channel.QueueDeclare(queueName, false, false, false, null);
                //serialize the received message
                var json = JsonConvert.SerializeObject(message);
                var body = Encoding.UTF8.GetBytes(json);
                //publish message
                channel.BasicPublish(exchange: "", routingKey: queueName, null, body: body);
            }
        }

        private void CreateConnection()
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = _hostName,
                    UserName = _userName,
                    Password = _password
                };

                _connection = factory.CreateConnection();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private bool ConnectionExists()
        {
            if(_connection != null )
            {
                return true;
            }
            CreateConnection();
            return true;
        }
    }
}
