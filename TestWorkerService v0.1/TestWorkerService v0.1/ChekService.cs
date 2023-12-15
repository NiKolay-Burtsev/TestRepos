using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TestWorkerService_v0._1
{
    internal class ChekService
    {
        public async void ChekServiceFromList()
        {
            string path = @"C:\Users\sierr\Desktop\1.txt";
            var dL = new ServiceList();
            dL.SetList();
            ServiceController[] services = ServiceController.GetServices(); //собираем список служб
            foreach (var service in services)
            {
                foreach (var s in dL.ArrayList)
                {
                    try
                    {
                        if (service.ServiceName == s && service.Status == ServiceControllerStatus.Stopped) //берем нужные службы
                        {
                            string text = $"{service.ServiceName}, {service.Status}";
                            service.WaitForStatus(ServiceControllerStatus.Stopped, new TimeSpan(0, 0, 5));
                            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate)) //  запись в .txt остановленных служб
                            {
                                byte[] buff = Encoding.Default.GetBytes(text);
                                await fs.WriteAsync(buff, 0, buff.Length);
                                fs.Close();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message.ToString());
                    }
                }
            }
        }
    }
}
