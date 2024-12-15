using FHS.Mobile.Enum;
using FHS.Mobile.Interfaces;
using Microsoft.AspNetCore.Components;

namespace FHS.Mobile.Services;
public class NavigationService(IAuthService _authService, NavigationManager _navigationManager) : INavigationService
{
    private const string Home = "/";
    private const string Login = "/login";
    private const string InvalidRoute = "/invalidRoute";

    public void NavigateTo(AppRoute appRoute)
    {
        var route = MapAppRouteToString(appRoute);

        if (!string.IsNullOrEmpty(route))
            GuardNavigate(route);
        else
            NavigateToDefault();
    }

    public void NavigateToDefault() =>
        GuardNavigate(Home);

    private void GuardNavigate(string route)
    {
        if (_authService.IsAuthenticated && !string.IsNullOrEmpty(route)) 
            _navigationManager.NavigateTo(route);
        else if (_authService.IsAuthenticated)
            _navigationManager.NavigateTo(Home);
        else 
            _navigationManager.NavigateTo(Login);
    }

    private static string? MapAppRouteToString(AppRoute route) =>
        route switch
        {
            AppRoute.Home => Home,
            AppRoute.Login => Login,
            _ => null
        };
}
