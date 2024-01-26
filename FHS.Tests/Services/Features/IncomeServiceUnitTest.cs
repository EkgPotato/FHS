using FHS.Entities.Dto.Features;
using FHS.Entities.ListModel.Features;
using FHS.Entities.Model.Features;
using FHS.Interfaces.Mapper.Features;
using FHS.Services.Service.Features;
using FHS.Tests.Services.Base;
using FHS.Tests.TestHelpers;
using Xunit;

namespace FHS.Tests.Services.Features
{
    public class IncomeServiceUnitTest : BaseCrudServiceUnitTest<IncomeListModel, IncomeModel, Income, IIncomeMapper, IncomeService>
    {
        public IncomeServiceUnitTest(DatabaseFixture<Income> fixture) : base(fixture)
        {
            _service = new IncomeService(_loggerMock.Object, _dbContext, _mapperMock.Object);
        }
    }
}
