using FHS.Entities.Dto.Features;
using FHS.Entities.ListModel.Features;
using FHS.Entities.Model.Features;
using FHS.Interfaces.Mapper.Base;

namespace FHS.Interfaces.Mapper.Features;

public interface IExpenseMapper : IBaseMapper<ExpenseListModel, ExpenseModel, Expense>
{

}