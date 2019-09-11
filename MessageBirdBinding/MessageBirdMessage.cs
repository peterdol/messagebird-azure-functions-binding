using System.Collections.Generic;
using Newtonsoft.Json;

namespace nrdkrmp.MessageBirdBinding
{
    public class MessageBirdMessage
    {
        [JsonProperty]
        public List<long> Recipients { get; set; }

        [JsonProperty]
        public string Body { get; set; }

        [JsonProperty]
        public string Originator { get; set; }
    }
}
