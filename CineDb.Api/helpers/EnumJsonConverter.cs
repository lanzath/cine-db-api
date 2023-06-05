using System.Text.Json;
using System.Text.Json.Serialization;

namespace CineDb.Api.helpers;

public sealed class EnumJsonConverter<T> : JsonConverter<T>
{
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string enumValue = reader.GetString();
        return (T)Enum.Parse(typeToConvert, enumValue, ignoreCase: true);
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}
