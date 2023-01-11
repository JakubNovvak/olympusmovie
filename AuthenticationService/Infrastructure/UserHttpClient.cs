using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MovieService.Infrastructure
{
    public class UserHttpClient
    {        
        private readonly HttpClient httpClient;

        public UserHttpClient()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            httpClient = new(clientHandler)
            {
                BaseAddress = new Uri("https://127.0.0.1:53155/api/User")
            };
        }

        public async Task<int> CreateUser(UserDTO userDTO)
        {
            var response = await httpClient.PostAsync("", JsonContent.Create(userDTO));
            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException($"Something went wrong, status code: {response.StatusCode}");
            }
            return await DeserializeIntegerFromResponse(response);
        }

        public async Task<int?> GetUser(string userName)
        {
            var response = await httpClient.GetAsync($"?username={userName}");
            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException($"Something went wrong, status code: {response.StatusCode}");
            }
            return (await DeserializeUserFromResponse(response))?.Id;
        }


        private static async Task<int> DeserializeIntegerFromResponse(HttpResponseMessage response)
        {
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<int>(responseBody);
        }

        private static async Task<UserDTO?> DeserializeUserFromResponse(HttpResponseMessage response)
        {
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserDTO?>(responseBody);
        }

        public class UserDTO
        {
            public int Id { get; set; }
            public string UserName { get; set; } = null!;
            public string Name { get; set; } = null!;
            public string Surname { get; set; } = null!;
            public string Email { get; set; } = null!;
            public string? Photo { get; set; }
            public string? BackgroundPhoto { get; set; }
            public DateTime JoinDate { get; set; }
        }
    }
}
