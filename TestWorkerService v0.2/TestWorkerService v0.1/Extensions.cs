using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWorkerService_v0._1
{
    public static class Extensions
    {
        public static string ToFormatedString(this Models.JsonFile file)
        {
            return string.Format("BotName: {0}\nFqdnName: {1}\nServiceName: {2}", file.BotName, file.MaсhineName, file.ServiceName);
        }
    }
}
