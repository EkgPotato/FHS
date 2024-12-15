using FHS.Mobile.Interfaces;

namespace FHS.Mobile.Services;
public class AuthService(IApiService _apiService) : IAuthService
{
    public bool IsAuthenticated { get; private set; } = false;

    public async Task Login(string username, string password)
    {
        try
        {
            var response = await _apiService.LoginAsync(username, password);
            IsAuthenticated = response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            IsAuthenticated = false;
        }
    }

    public void Logout()
    {
        IsAuthenticated = false;
    }
}
