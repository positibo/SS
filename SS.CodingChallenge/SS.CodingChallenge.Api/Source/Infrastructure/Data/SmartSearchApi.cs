using Newtonsoft.Json;
using SS.CodingChallenge.Api.Source.Domain.Models;
using System.Net.Http.Headers;
using System.Text;

namespace SS.CodingChallenge.Api.Source.Infrastructure.Data
{
    public class SmartSearchApi
    {
        private readonly HttpClient httpClient;
        private const string BaseUrl = "https://api2.smartsearchonline.com/openapi/v1";
        private const string ApiKey = "d5eca294-0570-4fa7-a06d-b8b50a1f3d2f";
        private const string UserName = "_Dev";
        private const string Password = "_Dev9199";

        public SmartSearchApi(HttpClient httpClient) => this.httpClient = httpClient;

        public async Task<Account> AuthenticateAsync()
        {
            httpClient.DefaultRequestHeaders.Add("X-API-KEY", ApiKey);
            var content = new StringContent(JsonConvert.SerializeObject(new { userName = UserName, password = Password }), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync($"{BaseUrl}/accounts", content);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Account>(responseBody);
            }

            throw new Exception($"Authentication failed: {response.ReasonPhrase}");
        }

        public async Task<List<Candidate>> GetCandidatesAsync(string zipCode)
        {
            var account = await AuthenticateAsync();
            if(string.IsNullOrEmpty(account.AccessToken))
            { 
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", account.AccessToken);

                var filter = string.IsNullOrEmpty(zipCode) ? "" : $"filter=candidatePostalCode eq '{zipCode}'";
                var response = await httpClient.GetAsync($"{BaseUrl}/candidates?{filter}");
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Candidate>>(responseBody);
                }

                throw new Exception($"Error: {response.ReasonPhrase} - {response.ReasonPhrase}");
            }

            throw new Exception($"Authentication failed");
        }
    }
}
