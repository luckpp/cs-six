using System;
using System.Threading.Tasks;

namespace CS6
{
    public class Worker: IDisposable
    {
        public Worker(Logger logger, string name = null)
        {
            if (name != null)
            {
                Name = name;
            }

            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public override string ToString() => $"Worker: {Name}";

        public void Dispose()
        {
            Logger?.Dispose();
        }

        public string Name { get; } = "Default-Name";

        private Logger Logger { get; }

        public async Task Execute(Action operation)
        {
            try
            {
                operation();
                await Logger.WriteLineAsync("Executed operation");
            }
            catch (WorkerException e) when (e.Code >= 0 && e.Code < 100)
            {
                await Logger.WriteLineAsync($"Error code {e.Code}");
            }
            catch (WorkerException)
            {
                await Logger.WriteLineAsync($"Unknown error code");
            }
            finally
            {
                await Logger.FlushAsync();
            }
        }
    }
}
