using FHS.Api.Controllers.Base;
using FHS.Entities.Dto.Dict;
using FHS.Entities.ListModel.Dict;
using FHS.Entities.Model.Dict;
using FHS.Interfaces.Services.Dict;

namespace FHS.Api.Controllers.Dict;

public class DictExpenseCategoryController : BaseController<DictExpenseCategoryListModel, DictExpenseCategoryModel, DictExpenseCategory, IDictExpenseCategoryService>
{
    public DictExpenseCategoryController(ILogger<DictExpenseCategoryController> logger, IDictExpenseCategoryService service) : base(logger, service)
    {
    }
}