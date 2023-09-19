using Azure.Messaging.ServiceBus;
using Ecommerce.Services.EmailAPI.DTO;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace Ecommerce.Services.EmailAPI.Messaging
{
    public class AzureServiceBusConsumer : IAzureServiceBusConsumer
    {
        private readonly string serviceBusConnectionString;
        private readonly string ecommerceCartQueue;
        private readonly IConfiguration _configuration;

        private ServiceBusProcessor _ecommerceCartProcessor;

        public AzureServiceBusConsumer(IConfiguration configuration)
        {
            _configuration = configuration;

            serviceBusConnectionString = _configuration.GetValue<string>("ServiceBusConnectionString");
            ecommerceCartQueue = _configuration.GetValue<string>("TopicAndQueueNames:EcommerceShoppingCartQueue");

            var client = new ServiceBusClient(serviceBusConnectionString);
            _ecommerceCartProcessor = client.CreateProcessor(ecommerceCartQueue);
        }

        public async Task Start()
        {
            _ecommerceCartProcessor.ProcessMessageAsync += OnEmailCartRequestReceived;
            _ecommerceCartProcessor.ProcessErrorAsync += ErrorHandler;
        }

        public async Task Stop()
        {
            await _ecommerceCartProcessor.StopProcessingAsync();
            await _ecommerceCartProcessor.DisposeAsync();
        }

        private async Task OnEmailCartRequestReceived(ProcessMessageEventArgs args)
        {
            var message = args.Message;
            var body = Encoding.UTF8.GetString(message.Body);

            CartDTO objMessage = JsonConvert.DeserializeObject<CartDTO>(body);
            try
            {
                //try to log email
                await args.CompleteMessageAsync(args.Message);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine(args.Exception.ToString());
            return Task.CompletedTask;
        }
    }
}
