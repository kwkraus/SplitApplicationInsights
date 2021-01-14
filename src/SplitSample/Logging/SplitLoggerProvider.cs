using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;

namespace SplitSample.Logging
{
    [ProviderAlias("Split")]
    public class SplitLoggerProvider : ILoggerProvider
    {
        public SplitLoggerProvider(IOptions<SplitLoggerOptions> options)
        {

        }

        public ILogger CreateLogger(string categoryName)
        {
            return new SplitLogger(categoryName);
        }

        public void Dispose()
        {
        }

        internal void AddMessage(DateTimeOffset timestamp, string v)
        {
            throw new NotImplementedException();
        }
    }
}