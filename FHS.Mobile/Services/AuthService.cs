using System.Net.Http.Json;
using FHS.Mobile.Interfaces;

namespace FHS.Mobile.Services;
public class AuthService(IApiService _apiService) : IAuthService
{
    public bool IsAuthenticated { get; private set; } = false;
    public async Task Login(string username, string password)
    {
        try
        {
            var loginData = new { Username = username, Password = password };
            var response =  await _apiService.Client.PostAsJsonAsync("api/Auth", loginData);
            IsAuthenticated = response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            IsAuthenticated = false;
        }
    }
}
