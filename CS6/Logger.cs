using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS6
{
    public class Logger : IEnumerable<string>, IDisposable
    {
        private Dictionary<int, string> data;

        public Logger()
        {
            data = new Dictionary<int, string>
            {
                [0] = "Logger has been initialized"
            };
        }

        public void WriteLine(string log)
        {
            if (IsLine(log))
            {
                data.Add(data.Count, log);
            }
        }

        public Task WriteLineAsync(string log)
        {
            WriteLine(log);
            return Task.FromResult(true);
        }

        public Task<string> GetLastLogAsync()
        {
            var result = this.Last();
            return Task.FromResult(result);
        }

        public Task FlushAsync()
        {
            return Task.FromResult(true);
        }

        public IEnumerator<string> GetEnumerator()
        {
            var logs = data.Select(keyValue => keyValue.Value);
            return logs.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Dispose()
        {
        }

        private static bool IsLine(string text) => text != null && !text.Contains(Environment.NewLine);
    }
}
