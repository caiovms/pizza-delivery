using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace pizza.delivery.Infrastructure.Serialization
{
    public static class GlobalSerialization
    {
        private static readonly Lazy<JsonSerializerOptions> DefaultOptionsFactory = new(
            () => CreateDefaultOptions(), isThreadSafe: true
        );

        public static JsonSerializerOptions DefaultOptions => DefaultOptionsFactory.Value;

        private static JsonSerializerOptions CreateDefaultOptions()
        {
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            return options;
        }
    }
}
