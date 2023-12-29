using System.Net.NetworkInformation;
using TestWin.Models;

namespace TestWin
{
    internal class ListServices
    {
        public List<Process> myList = new List<Process>();
        public void ListServicePath()
        {
            string path = @"C:\Users\Burtsev\source\repos\TestWin\TestWin\Models\json1.json";
            string line = File.ReadAllText(path);
            var file = ProcessSerializer.FromJson(line);
            myList.AddRange(file.Process);
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Проверка совместимости платформы", Justification = "<Ожидание>")]
        public void Chek()
        {
            bool pingger = false;
            Ping pinger = new Ping();
            PingReply reply = pinger.Send("Closer2.sns.gk");
            if (pingger = reply.Status == IPStatus.Success)
            {
                GetService();
            }
        }
        public void GetService()
        {
            
            foreach (var lines in myList)
            {
                var exp = new Extensions();
                var response = exp.ToFormated(lines);
                Console.WriteLine($"{response.Status}|{response.Discription}|{DateTime.Now}");
            }
        }
    }
}
