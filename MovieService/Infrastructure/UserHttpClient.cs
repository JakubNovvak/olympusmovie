using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MovieService.Infrastructure
{
    public class UserHttpClient
    {        
        private readonly HttpClient httpClient;
        private readonly string PRODUCTION_ID_PARAM = "productionId";

        public UserHttpClient()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            httpClient = new(clientHandler)
            {
                BaseAddress = new Uri("https://movieservice:443/api/User")
            };
        }
        
        public async Task<List<int>> GetProductionIdsOfUser(int userId, string typeOfProduction, string typeOfRelation)
        {
            var response = await httpClient.GetAsync($"/{userId}/{typeOfProduction}/{typeOfRelation}");
            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException($"Something went wrong, status code: {response.StatusCode}");
            }
            return await DeserializeListOfIntegersFromResponse(response);
        }

        public async Task<List<int>> SyncProductionIdsOfUser(int userId, string typeOfProduction, string typeOfRelation, ISet<int> productionIds)
        {
            var queryParamsString = GetQueryParamsString(productionIds, PRODUCTION_ID_PARAM);
            var response = await httpClient.PostAsync($"/{userId}/{typeOfProduction}/{typeOfRelation}/sync?{queryParamsString}", null);
            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException($"Something went wrong, status code: {response.StatusCode}");
            }
            return await DeserializeListOfIntegersFromResponse(response);
        }

        private static string GetQueryParamsString(ISet<int> values, string label)
        {
            return values.Select(id => label + "=" + id)
                .Aggregate((param1, param2) => param1 + "&" + param2);
        }

        private static async Task<List<int>> DeserializeListOfIntegersFromResponse(HttpResponseMessage response)
        {
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<int>>(responseBody) ?? new List<int>();
        }
    }
}
