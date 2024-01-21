namespace FHS.Entities.Interfaces.ListModel.Features
{
    public interface IIncomeListModel
    {
        string? CategoryName { get; set; }
        string? Name { get; set; }
        string? Time { get; set; }
        string? Value { get; set; }
    }
}