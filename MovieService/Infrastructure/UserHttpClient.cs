using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MovieService.Infrastructure
{
    public class UserHttpClient
    {
        private readonly HttpClient httpClient;
        private const string MOVIES = "Movies";
        private const string SERIES = "Series";
        private const string PLANNED_TO_WATCH = "PlannedToWatch";
        private const string WATCHED = "Watched";


        public UserHttpClient()
        {
            httpClient = new()
            {
                BaseAddress = new Uri("https://userservice:443/api/User")
            };
        }

        public async Task<List<int>> GetWatchedMoviesOfUser(int userId)
        {
            HttpResponseMessage response = await GetResponse(userId, $"{MOVIES}/{WATCHED}");
            return await DeserializeListOfIntegersFromResponse(response);
        }

        public async Task<List<int>> GetPlannedToWatchMoviesOfUser(int userId)
        {
            HttpResponseMessage response = await GetResponse(userId, $"{MOVIES}/{PLANNED_TO_WATCH}");
            return await DeserializeListOfIntegersFromResponse(response);
        }

        public async Task<List<int>> GetWatchedSeriesOfUser(int userId)
        {
            HttpResponseMessage response = await GetResponse(userId, $"{SERIES}/{WATCHED}");
            return await DeserializeListOfIntegersFromResponse(response);
        }

        public async Task<List<int>> GetPlannedToWatchSeriesOfUser(int userId)
        {
            HttpResponseMessage response = await GetResponse(userId, $"{SERIES}/{PLANNED_TO_WATCH}");
            return await DeserializeListOfIntegersFromResponse(response);
        }

        private async Task<HttpResponseMessage> GetResponse(int userId, string pathAfterUserId)
        {
            var response = await httpClient.GetAsync($"/{userId}/{pathAfterUserId}");
            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException($"Something went wrong, status code: {response.StatusCode}");
            }

            return response;
        }

        private static async Task<List<int>> DeserializeListOfIntegersFromResponse(HttpResponseMessage response)
        {
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<int>>(responseBody) ?? new List<int>();
        }
    }
}
