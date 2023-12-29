using System.ComponentModel;
using System.Net.Mail;
using System.ServiceProcess;
using TestWin.Models;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Buffers;

namespace TestWin
{
    public delegate void MyEventHandler();
    public class ServiceResponse
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .Build();
        
        public event MyEventHandler SomeEvent;
        private ServiceControllerStatus status;
        public string Discription { get; set; }
        public ServiceControllerStatus Status
        {
            get { return status; }
            set
            {
                status = value;
                if (status != value)
                {
                    status = ServiceControllerStatus.Running;
                }
            }
        }
        public void SendMessage(string mess)
        {
            var smtpclconf = Configuration.GetSection("Smtpclient");
            string host = smtpclconf.GetSection("host").Value;
            int port = Convert.ToInt32(smtpclconf.GetSection("port").Value);

            var from = "Nikolay.Burtsev@sns.ru";
            var to = "Nikolay.Burtsev@sns.ru";
            var subject = "ServiceWathcher: EVENT";
            var body = $"{mess}";
            var message = new MailMessage(from, to, subject, body);

            var client = new SmtpClient(host, port);
            client.Send(message);
        }
        public void afterEvent()
        {
            if (SomeEvent != null)
            {
                status = ServiceControllerStatus.Stopped;
                SomeEvent();
            }
        }
        
    }
    
    public  class Extensions
    {
        public ServiceResponse ProcessChek(Models.Process process)
        {
            var result = new ServiceResponse();
            var procsc = new ServiceController(process.Name, process.FqdnName);
            System.Diagnostics.Process[] proceses = System.Diagnostics.Process.GetProcesses(process.FqdnName);
            if(proceses.Length == 0)
            {
                result.Status = ServiceControllerStatus.Running;
                string info = $"Сервис: {procsc.ServiceName} - отвалился";
                result.SendMessage(info);
            }
            foreach(System.Diagnostics.Process process1 in proceses)
            {
                string str = procsc.ServiceName + ".exe";
                if(process1.ProcessName == procsc.ServiceName)
                {
                    
                }
            }
            return result;
        }
        public  ServiceResponse ServiceChek(Models.Process process)
        {
            var result = new ServiceResponse();
            try
            {
                var sc = new ServiceController(process.Name, process.FqdnName);
                ServiceController[] services = ServiceController.GetServices("Closer2.sns.gk");

                foreach (ServiceController service in services)
                {
                    string str = service.ServiceName + ".exe";
                    if (process.Name == str && service.Status == ServiceControllerStatus.Running)
                    {
                        result.Status = ServiceControllerStatus.Running;
                        string info = $"Сервис: {service.ServiceName} - отвалился";
                        result.SendMessage(info);
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                if (ex.InnerException is Win32Exception)
                {
                    result.Discription = ex.InnerException.Message;
                }
            }
            return result;
                
        }
    }
}
