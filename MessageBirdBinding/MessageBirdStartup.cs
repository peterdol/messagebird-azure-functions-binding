
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters.Json.Internal;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

[assembly: WebJobsStartup(typeof(nrdkrmp.MessageBirdBinding.MessageBirdStartup))]
namespace nrdkrmp.MessageBirdBinding
{
    public class MessageBirdStartup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            // see https://github.com/Azure/azure-functions-host/issues/3370
            builder.Services.AddTransient<IConfigureOptions<MvcOptions>, MvcJsonMvcOptionsSetup>();
            builder.AddExtension<MessageBirdConfiguration>();
        }
    }
}
