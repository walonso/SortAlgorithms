using Microsoft.AspNetCore.SignalR;
using SortingCore;
using SortingCore.Interfaces;
using SortingCore.Services;
using SortingCore.Services.GeneratorItems;
using SortingCore.Services.Sortables;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using static SortingCore.Services.TimeWatchSortable;

namespace WebSortAlgorithms
{
    public class SortHub : Hub
    {
        public async Task StartBubleSort()
        {
            string path = Directory.GetCurrentDirectory() + "/bubleSort.txt";
            SortFactory factory = new SortFactory();
            ISortable sortable = factory.GetSortable(Algorithm.BubbleSort);
            IGeneratorItems generatorItems = new AscendingGenerator();
            FileService fileService = new FileService();
            fileService.Delete(path);

            //var aTimer = new System.Timers.Timer(1000);
            //aTimer.Elapsed += aTimer_Elapsed;
            //aTimer.Interval = 3000;
            //aTimer.Enabled = true;

            await Sort(path, sortable, generatorItems, 10000, fileService);
            
            await Clients.All.SendAsync("ReceiveMessage", "text");
        }

        //void aTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        //{
        //    var context = ConnectionManager.GetHubContext<ChatHub>();
        //    Clients.All.addMessage("This message broadcasted on " + DateTime.Now);
        //}



        private async Task Sort(string path, ISortable sortable, IGeneratorItems generatorItems, int amount, FileService fileService)
        {
            var p = new Progress<TimeAndValue>(m =>
            {
                Clients.All.SendAsync("ReceiveMessage", m.time, m.value);
            });

            TimeWatchSortable timeWatchSortable = new TimeWatchSortable();
            timeWatchSortable.SetProgress(p);
            timeWatchSortable.SetSortable(sortable);

            List<int> list = generatorItems.GetData(amount);

            timeWatchSortable.Start();
            sortable.SortAscending(list);

            //fileService.Save(path, sortable.ToString());

            //Console.WriteLine("---- Analyze " + amount + " ----");
            //TimeWatch timer = new TimeWatch();
            //timer.Start();
            //List<int> list = generatorItems.GetData(amount);
            //Console.WriteLine("Time Loading List: " + timer.GetEllapsedMilliSeconds());

            //timer.Restart();
            //List<int> listOrderAsc = new List<int>(list);
            //List<int> listOrderDesc = new List<int>(list);
            //Console.WriteLine("Time Loading List to Order Asc or Desc:" + timer.GetEllapsedMilliSeconds());

            //timer.Restart();
            //List<int> orderedList = OrderAsc(sortable, listOrderAsc);
            //long timeAsc = timer.GetEllapsedMilliSeconds();
            //Console.WriteLine("Time Ordering Asc:" + timer.GetEllapsedMilliSeconds());

            //timer.Restart();
            //List<int> orderedDescList = OrderDesc(sortable, listOrderDesc);
            //long timeDesc = timer.GetEllapsedMilliSeconds();
            //Console.WriteLine("Time Ordering Desc:" + timer.GetEllapsedMilliSeconds());

            //fileService.Save(path, Environment.NewLine + $"Amount:{amount},TimeAsc:{timeAsc}, TimeDesc:{timeDesc}");

        }
    }
}
