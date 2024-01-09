using FHS.Entities.Dto.Features;

namespace FHS.Entities.Dto.Dict;

public sealed class DictIncomeCategory: BaseDictEntity
{    public DictIncomeCategory()
     {
         Incomes = new HashSet<Income>();
     }
 
     public ICollection<Income> Incomes { get; set; }

}