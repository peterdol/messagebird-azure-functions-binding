using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using nrdkrmp.MessageBirdBinding;

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
