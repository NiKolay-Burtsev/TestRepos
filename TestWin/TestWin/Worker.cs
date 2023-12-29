using System.Diagnostics;
using System.Net.NetworkInformation;
using System.ServiceProcess;

namespace TestWin
{
    public class Worker : BackgroundService
    {
        public interface INotiFieEvent
        {
            void SendEvent(string message);

        }
        public class ConsoleNotuFie : INotiFieEvent
        {
            public void SendEvent(string message)
            {
                Console.WriteLine(message);
            }
        }
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }
        
       
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            ListServices ls = new ListServices();
            ls.ListServicePath();
            ls.Chek();

            Thread.Sleep(5000);
            Console.Clear();
        }
    }
}
