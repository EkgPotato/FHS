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
            var handler = new HttpClientHandler();
#if DEBUG
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
#endif

            Client = new HttpClient(handler)
            {
                BaseAddress = new Uri("")
            };
        }

        public async Task<bool> CheckHealthAsync()
        {
            var response = await Client.GetAsync("api/Health");

            return response.IsSuccessStatusCode;
        }
    }
}