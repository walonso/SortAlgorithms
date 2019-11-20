using SortingCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SortingCore.Services
{
    public class TimeWatchSortable
    {
        ISortable Sortable;

        IProgress<TimeAndValue> Progress;

        public class TimeAndValue
        {
            public int value { get; set; }
            public long time { get; set; }
        }

        private System.Diagnostics.Stopwatch watch;

        public void SetProgress(IProgress<TimeAndValue> CallBack)
        {
            Progress = CallBack;
        }

        public void SetSortable(ISortable sortable)
        {
            var p = new Progress<int>(m =>
            {
                Progress?.Report(sendValue(m));
            });

            Sortable = sortable;
            Sortable.SetCallBackMethodByOrderedElement(p);
        }

        public ISortable GetSortable()
        {
            return Sortable;
        }

        public void Start()
        {
            watch = System.Diagnostics.Stopwatch.StartNew();                       
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
