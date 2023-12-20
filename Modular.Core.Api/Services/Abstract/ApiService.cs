using System.Net.Http.Headers;
using System;
using Microsoft.Extensions.Configuration;

namespace Modular.Core.Api
{

    public class ApiService : IApiService
    {

        private readonly HttpClient _httpClient;

        public ApiService(IConfiguration configuration) 
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(configuration["API_BASE_URL"] ?? "");
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
