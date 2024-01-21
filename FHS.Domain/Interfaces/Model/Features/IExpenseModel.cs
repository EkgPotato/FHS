namespace FHS.Entities.Interfaces.Model.Features
{
    public interface IExpenseModel
    {
        string? Description { get; set; }
        int? DictExpenseCategoryId { get; set; }
        string? Name { get; set; }
        DateTime? Time { get; set; }
        double? Value { get; set; }
    }
}