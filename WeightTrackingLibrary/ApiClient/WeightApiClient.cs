using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using WeightTrackingLibrary.ApiClient;

namespace WeightTrackingLibrary.ApiClient
{
    public class WeightApiClient<T>
    {
        private readonly HttpClient client;

        public WeightApiClient()
        {
            client = new();

        }

        public WeightApiClient(IConfiguration configuration) : this()
        {
        }

        public async Task<List<T>> GetWeight(IEnumerable<string?> API_KEY)
        {
            string WEIGHT_API_URL = null;
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(WEIGHT_API_URL),
                Headers =
            {
                { "X-RapidAPI-Key", API_KEY },
                { "X-RapidAPI-Host", "flixster.p.rapidapi.com" },
            },
            };
            using var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            return CreateWeightsFromJson(body);
        }

        public List<T> CreateWeightsFromJson(string json)
        {
            var res = JsonConvert.DeserializeObject<Response<T>>(json);
            return res?.data?.upcoming!;
        }
    }
}