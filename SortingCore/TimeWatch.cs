namespace SortingCore
{
    public class TimeWatch
    {
        private System.Diagnostics.Stopwatch watch;

        public void Start()
        {
            watch = System.Diagnostics.Stopwatch.StartNew();
            
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
        }

        public void Restart()
        {
            watch.Restart();
        }

        public void Stop()
        {
            watch.Stop();
        }

        public long GetEllapsedMilliSeconds()
        {
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }

    }
}
