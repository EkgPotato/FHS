using DataService.Data;
using FHS.Entities.Dto.Features;
using FHS.Entities.ListModel.Features;
using FHS.Entities.Model.Features;
using FHS.Interfaces.Services.Features;
using FHS.Services.Service.Base;
using FHS.Interfaces.Mapper.Features;
using Serilog;

namespace FHS.Services.Service.Features;

public sealed class ExpenseService : BaseCrudService<ExpenseListModel, ExpenseModel, Expense, IExpenseMapper>, IExpenseService
{
    public ExpenseService(ILogger logger, AppDbContext dbContext, IExpenseMapper mapper) : base(logger, dbContext, mapper)
    {
    }
}