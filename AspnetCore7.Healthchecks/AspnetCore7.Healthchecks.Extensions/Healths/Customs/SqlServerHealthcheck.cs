namespace AspnetCore7.Healthchecks.Extensions.Healths.Customs;

public class SqlServerHealthcheck : IHealthCheck
{
    private readonly BaseConfigurationOptions _options;

    public SqlServerHealthcheck(IOptionsMonitor<BaseConfigurationOptions> options)
    {
        _options = options.CurrentValue;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        using var conexao = new SqlConnection(_options.StringConexaoBancoDeDados);

        try
        {
            await conexao.OpenAsync();

            return new HealthCheckResult(
                HealthStatus.Healthy,
                description: HealthNames.SqlServerDescription);
        }
        catch (Exception ex)
        {
            return new HealthCheckResult(
                HealthStatus.Unhealthy,
                description: HealthNames.SqlServerDescriptionError);
        }
    }
}
