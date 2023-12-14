using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace TestWindowsService
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override async void OnStart(string[] args) //запускаем службу
        {
            while(true)
            {
                TestWindowsServiceDoList doList = new TestWindowsServiceDoList();
                doList.SetList();
                TestChekService chekService = new TestChekService();
                chekService.ChekServiceFromList();
                await Task.Delay(300);
            }
        }

        protected override void OnStop()
        {
        }
    }
}
