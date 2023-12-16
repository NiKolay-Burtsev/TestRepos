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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Проверка совместимости платформы", Justification = "<Ожидание>")]
        public async void ChekServiceFromList()
        {
            var dL = new ServiceList();
            dL.SetList();
            string path = "C:\\Users\\sierr\\source\\repos\\TestWorkerService v0.1\\TestWorkerService v0.1\\bin\\Debug\\1.txt";
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
                            using (StreamWriter sw = new StreamWriter(path, true))
                            {
                                await sw.WriteLineAsync(text);
                                sw.Close();
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
