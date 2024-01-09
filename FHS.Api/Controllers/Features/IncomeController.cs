using FHS.Api.Controllers.Base;
using FHS.Entities.Dto.Features;
using FHS.Entities.ListModel.Features;
using FHS.Entities.Model.Features;
using FHS.Services.Interfaces.Base;
using FHS.Services.Interfaces.Features;

namespace FHS.Api.Controllers.Features;

public class IncomeController : BaseController<IncomeListModel, IncomeModel, Income, IIncomeService>
{
    public IncomeController(ILogger<IncomeController> logger, IIncomeService service) : base(logger, service)
    {
    }
}