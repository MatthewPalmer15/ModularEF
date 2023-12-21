using System.Net.Http.Headers;

namespace Modular.Core.Api
{

    public class ApiService : IApiService
    {

        private readonly HttpClient _httpClient;

        public ApiService(string? baseUrl = null)
        {
            _httpClient = new HttpClient();

            if (baseUrl != null)
            {
                _httpClient.BaseAddress = new Uri(baseUrl);
            }

            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public async Task<string> GetAsync(string url, Guid id)
        {
            var response = await _httpClient.GetAsync($"{url}/{id.ToString()}");
            if (response.IsSuccessStatusCode)
            {
                var objects = response.Content.ReadAsStringAsync().Result;
                return objects;
            }
            else
            {
                return string.Empty;
            }

        }


    }

}
