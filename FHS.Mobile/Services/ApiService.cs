using FHS.Mobile.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FHS.Mobile.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        public ApiService()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("###")
            };
        }

        public async Task<HttpResponseMessage> LoginAsync(string username, string password)
        {
            var loginData = new { Username = username, Password = password };
            return await _httpClient.PostAsJsonAsync("###", loginData);
        }
    }
}
