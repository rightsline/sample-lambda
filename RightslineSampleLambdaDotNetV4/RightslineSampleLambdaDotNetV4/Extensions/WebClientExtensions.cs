using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace RightslineSampleLambdaDotNetV4.Extensions
{
    public static class WebClientExtensions
    {
        public async static Task<K> PostAsJsonAsync<T, K>(
               this WebRequest webClient, T data)
        {
            webClient.ContentType = "application/json";
            webClient.Method = "POST";

            using (var streamWriter = new StreamWriter(webClient.GetRequestStream()))
            {
                var dataAsString = JsonConvert.SerializeObject(data, new JsonSerializerSettings()
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });

                streamWriter.Write(dataAsString);
            }

            var response = await webClient.GetResponseAsync();

            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<K>(result);
            }
        }
    }
}
