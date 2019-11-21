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
        public async Task StartBubleSort(int amount)
        {
            SortFactory factory = new SortFactory();
            ISortable sortable = factory.GetSortable(Algorithm.BubbleSort);
            IGeneratorItems generatorItems = new AscendingGenerator();

            var p = new Progress<TimeAndValue>(m =>
            {
                Clients.All.SendAsync("ReceiveProgressSortBubble", m.time, m.value);
            });

            await Sort(sortable, generatorItems, amount, p);            
        }

        public async Task StartSelectionSort(int amount)
        {
            SortFactory factory = new SortFactory();
            ISortable sortable = factory.GetSortable(Algorithm.SelectionSort);
            IGeneratorItems generatorItems = new AscendingGenerator();

            var p = new Progress<TimeAndValue>(m =>
            {
                Clients.All.SendAsync("ReceiveProgressSortSelection", m.time, m.value);
            });


            await Sort(sortable, generatorItems, amount, p);
        }

        public async Task StartInsertionSort(int amount)
        {
            SortFactory factory = new SortFactory();
            ISortable sortable = factory.GetSortable(Algorithm.InsertionSort);
            IGeneratorItems generatorItems = new AscendingGenerator();

            var p = new Progress<TimeAndValue>(m =>
            {
                Clients.All.SendAsync("ReceiveProgressSortInsertion", m.time, m.value);
            });

            await Sort(sortable, generatorItems, amount, p);
        }

        private async Task Sort(ISortable sortable, IGeneratorItems generatorItems, int amount, IProgress<TimeAndValue> p)
        {
            TimeWatchSortable timeWatchSortable = new TimeWatchSortable();
            timeWatchSortable.SetProgress(p);
            timeWatchSortable.SetSortable(sortable);

            List<int> list = generatorItems.GetData(amount);

            timeWatchSortable.Start();
            await Task.Run(()=> sortable.SortAscending(list));
        }
    }
}
