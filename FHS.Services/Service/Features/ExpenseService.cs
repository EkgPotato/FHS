using DataService.Data;
using FHS.Entities.Dto.Features;
using FHS.Entities.ListModel.Features;
using FHS.Entities.Model.Features;
using FHS.Services.Interfaces.Features;
using FHS.Services.Service.Base;
using Mapper.Interfaces.Features;
using Mapper.Mappers.Features;
using Serilog;

namespace FHS.Services.Service.Features;

public sealed class ExpenseService : BaseCrudService<ExpenseListModel, ExpenseModel, Expense, IExpenseMapper>, IExpenseService
{
    public ExpenseService(ILogger<ExpenseService> logger, AppDbContext dbContext, IExpenseMapper mapper) : base(logger, dbContext, mapper)
    {
    }
}