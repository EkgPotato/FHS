using FHS.Entities.Dto.Dict;
using FHS.Entities.Dto.Features;
using FHS.Entities.ListModel.Dict;
using FHS.Entities.ListModel.Features;
using FHS.Entities.Model.Dict;
using FHS.Entities.Model.Features;
using FHS.Interfaces.Mapper.Features;
using FHS.Services.Service.Dict;
using FHS.Services.Service.Features;
using FHS.Tests.Services.Base;
using FHS.Tests.TestHelpers;
using Xunit;

namespace FHS.Tests.Services.Features
{
    public class DictExpenseCategoryServiceUnitTest : BaseCrudServiceUnitTest<DictExpenseCategoryListModel, DictExpenseCategoryModel, DictExpenseCategory, IDictExpenseCategoryMapper, DictExpenseCategoryService>
    {
        public DictExpenseCategoryServiceUnitTest(DatabaseFixture<DictExpenseCategory> fixture) : base(fixture)
        {
            _service = new DictExpenseCategoryService(_loggerMock.Object, _dbContext, _mapperMock.Object);
        }
    }
}
