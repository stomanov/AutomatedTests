using IntegrationTests.Models;
using Newtonsoft.Json;

namespace IntegrationTests.JsonExtension
{
    public static class JsonExtension
    {
        public static string ToJson(this Author self) => JsonConvert.SerializeObject(self, Converter.Converter.Settings);

        public static string ToJson(this Book self) => JsonConvert.SerializeObject(self, Converter.Converter.Settings);
    }
}