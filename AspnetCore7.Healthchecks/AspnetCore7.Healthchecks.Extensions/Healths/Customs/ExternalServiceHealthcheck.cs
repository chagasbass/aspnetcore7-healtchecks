namespace AspnetCore7.Healthchecks.Extensions.Healths.Customs;

public class ExternalServiceHealthcheck : IHealthCheck
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly BaseConfigurationOptions _options;

    private const string CEP = "24040110";

    public ExternalServiceHealthcheck(IHttpClientFactory clientFactory,
                                         IOptionsMonitor<BaseConfigurationOptions> options)
    {
        _clientFactory = clientFactory;
        _options = options.CurrentValue;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        var url = _options.UrlServicoCep.Replace("meu_cep", CEP);

        using var clienteHttp = _clientFactory.CreateClient();

        try
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await clienteHttp.SendAsync(request);

            if (!response.IsSuccessStatusCode)
                return new HealthCheckResult(
               HealthStatus.Unhealthy,
               description: HealthNames.ExternalServicesDescriptionError);
        }
        catch
        {
            return new HealthCheckResult(
                HealthStatus.Unhealthy,
                description: HealthNames.ExternalServicesDescriptionError);
        }

        return new HealthCheckResult(
                HealthStatus.Healthy,
                description: HealthNames.ExternalServicesDescription);
    }
}