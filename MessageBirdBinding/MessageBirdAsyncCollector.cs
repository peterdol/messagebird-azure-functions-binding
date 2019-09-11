using MessageBird;
using Microsoft.Azure.WebJobs;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace nrdkrmp.MessageBirdBinding
{
    public class MessageBirdAsyncCollector : IAsyncCollector<MessageBirdMessage>
    {
        private MessageBirdConfiguration config;
        private MessageBirdAttribute attr;


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
