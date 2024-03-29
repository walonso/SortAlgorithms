﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SortingCore.Interfaces;
using SortingCore.Services.GeneratorItems;
using SortingCore.Services.Sortables;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace WebSortAlgorithms.Controllers
{
    [Route("Sort")]
    public class SortController : Controller
    {
        private readonly IHubContext<SortHub, ISortHubClient> _hubContext;

        public SortController(IHubContext<SortHub, ISortHubClient> hubContext)
        {
            _hubContext = hubContext;
        }

        [Route("RunBubbleSortAscending/{amount}")]
        public async Task RunBubbleSortAcending(int amount)
        {
            SortFactory factory = new SortFactory();
            ISortable sortable = factory.GetSortable(Algorithm.BubbleSort);
            IGeneratorItems generatorItems = new AscendingGenerator();
            CancellationTokenSource cts = new CancellationTokenSource();
            
            var p = new Progress<SortingCore.Services.TimeWatchSortable.TimeAndValue>(async m =>
            {
                await _hubContext.Clients.All.ReceiveProgressAscSortBubble(m.time, m.value);
            });

            await Sort(sortable, generatorItems, amount, p, cts);
        }

        [Route("RunSelectionSortAscending/{amount}")]
        public async Task RunSelectionSortAcending(int amount)
        {
            SortFactory factory = new SortFactory();
            ISortable sortable = factory.GetSortable(Algorithm.SelectionSort);
            IGeneratorItems generatorItems = new AscendingGenerator();
            CancellationTokenSource cts = new CancellationTokenSource();

            var p = new Progress<SortingCore.Services.TimeWatchSortable.TimeAndValue>(async m =>
            {
                await _hubContext.Clients.All.ReceiveProgressAscSortSelection(m.time, m.value);
            });

            await Sort(sortable, generatorItems, amount, p, cts);
        }

        [Route("RunInsertionSortAscending/{amount}")]
        public async Task RunInsertionSortAcending(int amount)
        {
            SortFactory factory = new SortFactory();
            ISortable sortable = factory.GetSortable(Algorithm.InsertionSort);
            IGeneratorItems generatorItems = new AscendingGenerator();
            CancellationTokenSource cts = new CancellationTokenSource();

            var p = new Progress<SortingCore.Services.TimeWatchSortable.TimeAndValue>(async m =>
            {
                await _hubContext.Clients.All.ReceiveProgressAscSortInsertion(m.time, m.value);
            });

            await Sort(sortable, generatorItems, amount, p, cts);
        }

        [Route("RunShellSortAscending/{amount}")]
        public async Task RunShellSortAscending(int amount)
        {
            SortFactory factory = new SortFactory();
            ISortable sortable = factory.GetSortable(Algorithm.ShellSort);
            IGeneratorItems generatorItems = new AscendingGenerator();
            CancellationTokenSource cts = new CancellationTokenSource();

            var p = new Progress<SortingCore.Services.TimeWatchSortable.TimeAndValue>(async m =>
            {
                await _hubContext.Clients.All.ReceiveProgressAscSortShell(m.time, m.value);
            });

            await Sort(sortable, generatorItems, amount, p, cts);
        }

        [Route("RunQuickSortAscending/{amount}")]
        public async Task RunQuickSortAscending(int amount)
        {
            SortFactory factory = new SortFactory();
            ISortable sortable = factory.GetSortable(Algorithm.QuickSort);
            IGeneratorItems generatorItems = new AscendingGenerator();
            CancellationTokenSource cts = new CancellationTokenSource();

            var p = new Progress<SortingCore.Services.TimeWatchSortable.TimeAndValue>(async m =>
            {
                await _hubContext.Clients.All.ReceiveProgressAscSortQuick(m.time, m.value);
            });

            await Sort(sortable, generatorItems, amount, p, cts);
        }

        [Route("RunMergeSortAscending/{amount}")]
        public async Task RunMergeSortAscending(int amount)
        {
            SortFactory factory = new SortFactory();
            ISortable sortable = factory.GetSortable(Algorithm.MergeSort);
            IGeneratorItems generatorItems = new AscendingGenerator();
            CancellationTokenSource cts = new CancellationTokenSource();

            var p = new Progress<SortingCore.Services.TimeWatchSortable.TimeAndValue>(async m =>
            {
                await _hubContext.Clients.All.ReceiveProgressAscSortMerge(m.time, m.value);
            });

            await Sort(sortable, generatorItems, amount, p, cts);
        }

        private async Task Sort(ISortable sortable, IGeneratorItems generatorItems, int amount, IProgress<SortingCore.Services.TimeWatchSortable.TimeAndValue> p, CancellationTokenSource cts)
        {
            SortingCore.Services.TimeWatchSortable timeWatchSortable = new SortingCore.Services.TimeWatchSortable();
            timeWatchSortable.SetProgress(p);
            timeWatchSortable.SetSortable(sortable);

            List<int> list = generatorItems.GetData(amount);

            timeWatchSortable.Start();
            await Task.Run(() => sortable.SortAscending(list));
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public ActionResult RunBubbleSort([Bind(Prefix = "id")] string connId)
        //{
        //    var context = GlobalHost.ConnectionManager.GetHubContext<SortHub>();
        //    context.Clients.All.methodInJavascript("hello world");
        //    // or
        //    context.Clients.Group("groupname").methodInJavascript("hello world");
        //}
    }
}