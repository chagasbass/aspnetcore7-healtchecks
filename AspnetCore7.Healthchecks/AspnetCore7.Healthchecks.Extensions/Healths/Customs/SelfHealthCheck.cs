namespace AspnetCore7.Healthchecks.Extensions.Health.Customs;

/// <summary>
/// Healthcheck customizado para monitoramento da própria aplicação
/// </summary>
public class SelfHealthCheck : IHealthCheck
{
    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        return new HealthCheckResult(
            HealthStatus.Healthy,
            description: HealthNames.SelfDescription);
    }
}