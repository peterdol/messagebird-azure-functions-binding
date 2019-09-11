using Microsoft.Azure.WebJobs.Host.Config;
using Newtonsoft.Json.Linq;

namespace nrdkrmp.MessageBirdBinding
{
    public class MessageBirdConfiguration : IExtensionConfigProvider
    {
        void IExtensionConfigProvider.Initialize(ExtensionConfigContext context)
        {
            // Converting our custom object to a JObject, and back again - used for JavaScript / Java functions using this binding
            context.AddConverter<JObject, MessageBirdMessage>(input => input.ToObject<MessageBirdMessage>());
            context.AddConverter<MessageBirdMessage, JObject>(input => JObject.FromObject(input));

            context.AddBindingRule<MessageBirdAttribute>()
                .BindToCollector<MessageBirdMessage>(attr => new MessageBirdAsyncCollector(this, attr));
        }
    }
}
