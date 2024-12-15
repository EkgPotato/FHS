using FHS.Mobile.Enum;

namespace FHS.Mobile.Interfaces;
public interface INavigationService
{
    void NavigateTo(AppRoute appRoute);
    void NavigateToDefault();
}
