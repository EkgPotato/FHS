using FHS.Api.Controllers.Dict;
using FHS.Entities.Dto.Dict;
using FHS.Entities.ListModel.Dict;
using FHS.Entities.Model.Dict;
using FHS.Interfaces.Services.Dict;
using FHS.Tests.Api.Controllers.Base;

namespace FHS.Tests.Api.Controllers.Features
{
    public class DictIncomeCategoryControllerUnitTest : BaseControllerUnitTests<DictIncomeCategoryListModel, DictIncomeCategoryModel, DictIncomeCategory, DictIncomeCategoryController, IDictIncomeCategoryService>
    {
        public DictIncomeCategoryControllerUnitTest() : base()
        {
            _controller = new DictIncomeCategoryController(_loggerMock.Object, _serviceMock.Object);
        }
    }
}
