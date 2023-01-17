namespace AspnetCore7.Healthchecks.Extensions.DependencyInjection
{
    public static class OptionsExtensions
    {
        public static IServiceCollection AddOptionsPattern(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<BaseConfigurationOptions>(configuration.GetSection(BaseConfigurationOptions.BaseConfig));
            services.Configure<HealthchecksConfigurationOptions>(configuration.GetSection(HealthchecksConfigurationOptions.BaseConfig));

            return services;
        }
    }
}