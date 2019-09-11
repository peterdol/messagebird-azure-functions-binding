using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace nrdkrmp.MessageBirdBinding.ExampleCSharp
{
    public class MessageBirdCSharp
    {
        [FunctionName("MessageBirdCSharp")]
        public IActionResult Run(
            [HttpTrigger] MessageBirdMessage inputMessage,
            [MessageBird(WebHookUrl = "MessageBirdWebHookUrl", ApiKey = "MessageBirdApiKey")] out MessageBirdMessage outputMessage,
            ILogger log)
        {
            outputMessage = inputMessage;

            return new OkObjectResult($"Send message to: {inputMessage.Recipients}.");
        }

    }
}
