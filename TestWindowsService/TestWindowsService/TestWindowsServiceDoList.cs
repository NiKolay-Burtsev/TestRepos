using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWindowsService
{
    internal class TestWindowsServiceDoList
    {
        public List<string> ArrayList = new List<string>();
        public void SetList() // создаем метод записи считываемых названий служб
        {
            string path = @"C:\Users\sierr\source\repos\TestChekService\TestChekService\bin\Debug\TestChek.txt";
            using (StreamReader streamReader = new StreamReader(path))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    ArrayList.Add(line);
                }
            }
        }
    }
}
