using FHS.Entities.Dto.Dict;

namespace FHS.Entities.Dto.Features
{
    public interface IExpense
    {
        string? Description { get; set; }
        DictExpenseCategory? DictExpenseCategory { get; set; }
        int? DictExpenseCategoryId { get; set; }
        string? Name { get; set; }
        DateTime? Time { get; set; }
        double? Value { get; set; }
    }
}