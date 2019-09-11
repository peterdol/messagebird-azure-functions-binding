using MessageBird;
using Microsoft.Azure.WebJobs;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace nrdkrmp.MessageBirdBinding
{
    public class MessageBirdAsyncCollector : IAsyncCollector<MessageBirdMessage>
    {
        private MessageBirdConfiguration config;
        private MessageBirdAttribute attr;

        private static readonly JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            },
            Formatting = Formatting.Indented
        };


        public MessageBirdAsyncCollector(MessageBirdConfiguration config, MessageBirdAttribute attr)
        {
            this.config = config;
            this.attr = attr;
        }

        public Task AddAsync(MessageBirdMessage item, CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                var client = Client.CreateDefault(attr.ApiKey);
                var response = client.SendMessage(item.Originator, item.Body, item.Recipients.ToArray());

                Console.Write(response);
            }
            catch (Exception e)
            {
                Console.Write(e);
            }

            return Task.CompletedTask;
        }

        public Task FlushAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.CompletedTask;
        }
    }
}
