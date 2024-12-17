namespace FHS.Mobile.Interfaces
{
    public interface IAuthService
    {
        bool IsAuthenticated { get; }
        Task Login(string username, string password);
    }
}