

using System.Diagnostics;

namespace BookHive.Application.Utilities
{
    public class PerformanceMeter : IDisposable
    {
        private readonly Stopwatch _stopwatch;
        private readonly string _operationName;

        public PerformanceMeter(string operationName)
        {
            _operationName = operationName;
            _stopwatch = Stopwatch.StartNew();
        }

        public void Dispose()
        {
            _stopwatch.Stop();
            Console.WriteLine($"'{_operationName}' executed in: {_stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
