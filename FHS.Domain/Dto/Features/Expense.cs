using FHS.Entities.Dto.Dict;

namespace FHS.Entities.Dto.Features;

public sealed class Expense : BaseEntity, IExpense
{
    public string? Name { get; set; }

    public double? Value { get; set; }

    public DateTime? Time { get; set; }

    public string? Description { get; set; }
    public DictExpenseCategory? DictExpenseCategory { get; set; }

    public int? DictExpenseCategoryId { get; set; }
}