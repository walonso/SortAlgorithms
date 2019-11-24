using Microsoft.AspNetCore.Mvc;
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

        [Route("RunBubbleSort/{amount}")]
        public async Task RunBubbleSort(int amount)
        {
            SortFactory factory = new SortFactory();
            ISortable sortable = factory.GetSortable(Algorithm.BubbleSort);
            IGeneratorItems generatorItems = new AscendingGenerator();
            CancellationTokenSource cts = new CancellationTokenSource();
            
            var p = new Progress<SortingCore.Services.TimeWatchSortable.TimeAndValue>(async m =>
            {
                await _hubContext.Clients.All.ReceiveProgressSortBubble(m.time, m.value);
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