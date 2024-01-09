using FHS.Entities.Dto.Features;
using FHS.Entities.ListModel.Features;
using FHS.Entities.Model.Features;
using Mapper.Interfaces.Base;

namespace Mapper.Interfaces.Features;

public interface IExpenseMapper : IBaseMapper<ExpenseListModel, ExpenseModel, Expense>
{
    
}