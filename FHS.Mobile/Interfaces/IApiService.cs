namespace FHS.Mobile.Interfaces
{
    public interface IApiService
    {
        HttpClient Client { get; }
        Task<bool> CheckHealthAsync();
    }
}