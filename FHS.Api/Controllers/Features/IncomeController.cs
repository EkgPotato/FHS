using FHS.Api.Controllers.Base;
using FHS.Entities.Dto.Features;
using FHS.Entities.ListModel.Features;
using FHS.Entities.Model.Features;
using FHS.Interfaces.Services.Features;

namespace FHS.Api.Controllers.Features;

public class IncomeController : BaseController<IncomeListModel, IncomeModel, Income, IIncomeService>
{
    public IncomeController(ILogger<IncomeController> logger, IIncomeService service) : base(logger, service)
    {
    }
}