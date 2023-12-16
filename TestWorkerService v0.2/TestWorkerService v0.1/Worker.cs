namespace TestWorkerService_v0._1
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                ChekService chekService = new ChekService();
                chekService.ChekServiceFromList();
                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}
