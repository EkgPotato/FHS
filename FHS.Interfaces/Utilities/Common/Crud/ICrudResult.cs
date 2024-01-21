namespace FHS.Interfaces.Common.Crud
{
    public interface ICrudResult
    {
        List<string> Messages { get; set; }

        void AddMessage(string message);
        bool Succeed();
    }
}