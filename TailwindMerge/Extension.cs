using Microsoft.Extensions.DependencyInjection;

namespace TailwindMerge.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTailwindMerge(this IServiceCollection services, Action<TailwindMergeConfig> configure = null)
        {
            // Optional: Configuration logic here, if needed

            // Add TailwindMerge to services
            services.AddSingleton<TailwindMerge>();

            return services;
        }
    }
}