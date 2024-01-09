using FHS.Entities.Dto.Features;
using FHS.Entities.ListModel.Features;
using FHS.Entities.Model.Features;
using Mapper.Interfaces.Features;
using Mapper.Mappers.Base;

namespace Mapper.Mappers.Features;

public sealed class ExpenseMapper : BaseMapper<ExpenseListModel, ExpenseModel, Expense>, IExpenseMapper
{
}