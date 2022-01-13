using pizza.delivery.Infrastructure.Serialization;
using System;
using System.Text.Json;

namespace pizza.delivery.Infrastructure.Extensions
{
    public static class ObjectExtensions
    {
        public static string ToJson<T>(this T source, JsonSerializerOptions options = null)
        {
            var json = ToJson(source, source?.GetType(), options);

            return json;
        }

        public static string ToJson(this object source, Type type, JsonSerializerOptions options = null)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            var optionsInternal = options ?? GlobalSerialization.DefaultOptions;

            var json = JsonSerializer.Serialize(source, type, optionsInternal);

            return json;
        }
    }
}