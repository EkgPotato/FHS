using FHS.Entities.Dto.Features;
using FHS.Entities.ListModel.Features;
using FHS.Entities.Model.Features;
using FHS.Interfaces.Services.Base;

namespace FHS.Interfaces.Services.Features;

public interface IExpenseService : IBaseCrudService<ExpenseListModel, ExpenseModel, Expense>
{

}