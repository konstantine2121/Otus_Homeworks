using System.Diagnostics;

namespace Reflection
{
    internal class TimeMeasurmentUtility
    {
        public static long MearureElapsedTicks(Action action)
        {
            if (action == null)
                return 0;

            Stopwatch sw = Stopwatch.StartNew();
            
            action();
            
            sw.Stop();

            return sw.ElapsedTicks;
        }
    }
}
