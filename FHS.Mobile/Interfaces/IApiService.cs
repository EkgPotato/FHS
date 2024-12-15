namespace FHS.Mobile.Interfaces
{
    public interface IApiService
    {
        Task<HttpResponseMessage> LoginAsync(string username, string password);
    }
}