using FHS.Api.Controllers.Base;
using FHS.Entities.Dto.Dict;
using FHS.Entities.Dto.Features;
using FHS.Entities.ListModel.Dict;
using FHS.Entities.ListModel.Features;
using FHS.Entities.Model.Dict;
using FHS.Entities.Model.Features;
using FHS.Interfaces.Services.Dict;
using FHS.Interfaces.Services.Features;

namespace FHS.Api.Controllers.Dict;

public class DictIncomeCategoryController : BaseController<DictIncomeCategoryListModel, DictIncomeCategoryModel, DictIncomeCategory, IDictIncomeCategoryService>
{
    public DictIncomeCategoryController(ILogger<DictIncomeCategoryController> logger, IDictIncomeCategoryService service) : base(logger, service)
    {
    }
}