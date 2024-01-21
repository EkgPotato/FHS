using FHS.Api.Controllers.Base;
using FHS.Entities.Dto.Features;
using FHS.Entities.ListModel.Features;
using FHS.Entities.Model.Features;
using FHS.Interfaces.Services.Features;

namespace FHS.Api.Controllers.Features;

public class ExpenseController : BaseController<ExpenseListModel, ExpenseModel, Expense, IExpenseService>
{
    public ExpenseController(ILogger<ExpenseController> logger, IExpenseService service) : base(logger, service)
    {
    }
}