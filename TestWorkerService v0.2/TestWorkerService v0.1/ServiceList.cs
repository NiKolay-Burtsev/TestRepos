using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWorkerService_v0._1
{
    internal class ServiceList
    {
        public List<object> ArrayList = new List<object>();
        public void SetList() // создаем метод записи считываемых названий служб
        {
            var path = Path.Combine(Environment.CurrentDirectory, "Json.txt");
            var json = File.ReadAllText(path);

            Models.JsonFile file = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.JsonFile>(json);
            Console.WriteLine(file.ToFormatedString());

            ArrayList.Add(file.ToFormatedString());
        }
    }
}
