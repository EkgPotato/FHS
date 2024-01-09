using FHS.Entities.Dto.Features;

namespace FHS.Entities.Dto.Dict;

public sealed class DictExpenseCategory : BaseDictEntity
{
    public DictExpenseCategory()
    {
        Expenses = new HashSet<Expense>();
    }

    public ICollection<Expense> Expenses { get; set; }
}