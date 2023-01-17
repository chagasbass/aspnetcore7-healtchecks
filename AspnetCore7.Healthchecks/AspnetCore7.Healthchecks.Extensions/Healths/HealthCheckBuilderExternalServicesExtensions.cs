
namespace AspnetCore7.Healthchecks.Extensions.Healths;

public static class HealthCheckBuilderExternalServicesExtensions
{

    public static IHealthChecksBuilder AddExternalServicesCheck(this IHealthChecksBuilder builder, string name, HealthStatus? failureStatus = null, IEnumerable<string> tags = null)
    {
        builder.AddCheck<ExternalServiceHealthcheck>(name, failureStatus ?? HealthStatus.Degraded, tags);

        return builder;
    }
}