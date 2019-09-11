using Microsoft.Azure.WebJobs.Description;
using System;
using System.Collections.Generic;
using System.Text;

namespace nrdkrmp.MessageBirdBinding
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    [Binding]
    public class MessageBirdAttribute : Attribute
    {
        [AppSetting]
        public string WebHookUrl { get; set; }

        [AppSetting]
        public string ApiKey { get; set; }
    }
}
