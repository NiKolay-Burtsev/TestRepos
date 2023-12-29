using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TestWin.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ProcessSerializer
    {
        [JsonProperty("Process", NullValueHandling = NullValueHandling.Ignore)]
        public List<Process> Process { get; set; }
    }

    public partial class Process
    {
        [JsonProperty("fqdnName", NullValueHandling = NullValueHandling.Ignore)]
        public string FqdnName { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
    }

    public partial class ProcessSerializer
    {
        public static ProcessSerializer FromJson(string json) => JsonConvert.DeserializeObject<ProcessSerializer>(json, TestWin.Models.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this ProcessSerializer self) => JsonConvert.SerializeObject(self, TestWin.Models.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
