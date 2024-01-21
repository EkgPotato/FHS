using FHS.Entities.Dto.Features;

namespace FHS.Domain.Interfaces.Dto.Dict

{
    public interface IDictExpenseCategory
    {
        ICollection<Expense> Expenses { get; set; }
    }
}