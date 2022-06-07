using System.Text.Json;

namespace Bachelor.Thesis.Benchmarking.WebApi.Database;

public static class JsonConverter
{
    public static JsonSerializerOptions Options { get; } = new ()
    {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DictionaryKeyPolicy = JsonNamingPolicy.CamelCase
    };

    public static string Serialize(object value)
    {
        return JsonSerializer.Serialize(value, Options);
    }

    public static object? Deserialize(string value, Type T)
    {
        var deserializedObject = JsonSerializer.Deserialize(value, T);

        // TODO: cast object into right type

        return deserializedObject;
    }
}