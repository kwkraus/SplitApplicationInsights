using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using SplitSample.Logging;
using System;

namespace SplitSample.Extensions
{
    public static class SplitLoggerFactoryExtensions
    {
        public static ILoggingBuilder AddSplit(this ILoggingBuilder builder)
        {
            builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<ILoggerProvider, SplitLoggerProvider>());

            return builder;
        }

        public static ILoggingBuilder AddSplit(this ILoggingBuilder builder, Action<SplitLoggerOptions> configure)
        {
            builder.AddSplit();
            builder.Services.Configure(configure);

            return builder;
        }
    }
}
