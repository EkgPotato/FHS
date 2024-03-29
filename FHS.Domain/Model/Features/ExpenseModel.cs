using FHS.Entities.Interfaces.Model.Features;

namespace FHS.Entities.Model.Features;

public sealed class ExpenseModel : BaseModel, IExpenseModel
{
    public string? Name { get; set; }

    public double? Value { get; set; }

    public DateTime? Time { get; set; }

    public int? DictExpenseCategoryId { get; set; }

    public string? Description { get; set; }
}