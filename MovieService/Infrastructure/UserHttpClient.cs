using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MovieService.Infrastructure
{
    public class UserHttpClient
    {
        public static class TypesOfProduction
        {
            public const string MOVIE = "Movies";
            public const string SERIES = "Series";
            public const string SEASON = "Seasons";            
        }
        public static class TypesOfRelation
        {
            public const string PLAN_TO_WATCH = "PlanToWatch";
            public const string WATCHED = "Watched";
            public const string ON_HOLD = "OnHold";
            public const string DROPPED = "Dropped";
            public const string FAVORITE = "Favorite";
        }
        
        private readonly HttpClient httpClient;
        private readonly string PRODUCTION_ID_PARAM = "productionId";

        public UserHttpClient()
        {
            httpClient = new()
            {
                BaseAddress = new Uri("https://userservice:443/api/User")
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

        private async Task<string> GetUserName(int userId)
        {
            var userName = await httpClient.GetAsync($"/{userId}/userName");
            var responseBody = await userName.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<string>(responseBody) ?? string.Empty;
        }
    }
}
