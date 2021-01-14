using Microsoft.Extensions.DependencyInjection;
using Split.ApplicationInsights.Extensions;

namespace Split.AspNetCore.ApplicationInsights.Extensions.Extensions
{
    public static class SplitServiceCollectionExtensions
    {
        public static IServiceCollection AddSplitTelemetryProvider(this IServiceCollection services)
        {
            services.AddApplicationInsightsTelemetryProcessor<SplitTelemetryProcessor>();
            return services;
        }
    }
}
