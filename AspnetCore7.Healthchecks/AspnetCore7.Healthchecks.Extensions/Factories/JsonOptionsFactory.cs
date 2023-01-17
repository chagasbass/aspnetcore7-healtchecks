namespace AspnetCore7.Healthchecks.Factories;

public static class JsonOptionsFactory
{
    public static JsonSerializerOptions GetSerializerOptions()
    {
        return new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

    }
}