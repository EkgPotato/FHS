using DataService.Data;
using FHS.Entities.Dto.Features;
using FHS.Entities.ListModel.Features;
using FHS.Entities.Model.Features;
using FHS.Interfaces.Services.Features;
using FHS.Services.Service.Base;
using FHS.Interfaces.Mapper.Features;
using Mapper.Mappers.Features;
using Serilog;

namespace FHS.Services.Service.Features;

public sealed class IncomeService : BaseCrudService<IncomeListModel, IncomeModel, Income, IIncomeMapper>, IIncomeService
{
    public IncomeService(ILogger logger, AppDbContext dbContext, IIncomeMapper mapper) : base(logger, dbContext, mapper)
    {
    }
}