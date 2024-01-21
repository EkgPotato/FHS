using FHS.Entities.Dto.Features;

namespace FHS.Domain.Interfaces.Dto.Dict
{
    public interface IDictIncomeCategory
    {
        ICollection<Income> Incomes { get; set; }
    }
}