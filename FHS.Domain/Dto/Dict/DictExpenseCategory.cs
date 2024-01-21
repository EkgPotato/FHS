using FHS.Entities.Dto.Features;
using FHS.Domain.Interfaces.Dto.Dict;

namespace FHS.Entities.Dto.Dict;

public sealed class DictExpenseCategory : BaseDictEntity, IDictExpenseCategory
{
    public DictExpenseCategory()
    {
        Expenses = new HashSet<Expense>();
    }

    public ICollection<Expense> Expenses { get; set; }
}