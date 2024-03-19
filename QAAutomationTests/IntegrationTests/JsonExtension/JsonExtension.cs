using Newtonsoft.Json;

namespace IntegrationTests.JsonExtension
{
    public static class JsonExtension
    {
        public static T FromJson<T>(this string json) => JsonConvert.DeserializeObject<T>(json, Converter.Converter.Settings);

        public static string ToJson<T>(this T self) => JsonConvert.SerializeObject(self, Converter.Converter.Settings);
    }
}