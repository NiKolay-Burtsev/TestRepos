using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWorkerService_v0._1.Models
{
    public class JsonFile
    {
        [Newtonsoft.Json.JsonProperty("BotName")]
        public string BotName { get; set; }

        [Newtonsoft.Json.JsonProperty("FqdnName")]
        public string MaсhineName { get; set; }

        [Newtonsoft.Json.JsonProperty("ServiceName")]
        public string ServiceName { get; set; }

    }
}
