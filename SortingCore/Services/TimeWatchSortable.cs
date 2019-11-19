using SortingCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SortingCore.Services
{
    public class TimeWatchSortable
    {
        ISortable Sortable;

        public class TimeAndValue
        {
            public int value { get; set; }
            public long time { get; set; }
        }

        private System.Diagnostics.Stopwatch watch;

        public static int CallBackByOrderedElement(int n)
        {
            //sendValue(n);
            return n;
        }
        //Func<int, int> CallBack = CallBackByOrderedElement;

        public void SetSortable(ISortable sortable)
        {
            Sortable = sortable;
            Sortable.SetCallBackMethodByOrderedElement(CallBackByOrderedElement);
        }

        public void Start()
        {
            watch = System.Diagnostics.Stopwatch.StartNew();

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
        }

        public TimeAndValue sendValue(int number)
        {
            return new TimeAndValue()
            {
                value = number,
                time = watch.ElapsedMilliseconds
            };
        }

        public void Stop()
        {
            watch.Stop();
        }
    }
}
