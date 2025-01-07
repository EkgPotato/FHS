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
        public HttpClient Client { get; }
        public ApiService()
        {
            //TODO: ONLY FOR DEBUG
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };
            
            Client = new HttpClient()
            {
                BaseAddress = new Uri("/")
            };
        }

        public async Task<bool> CheckHealthAsync()
        {
            var response = await Client.GetAsync("api/Health");

            return response.IsSuccessStatusCode;
        }
    }
}
