using FHS.Api.Controllers.Features;
using FHS.Domain.Interfaces.Model.Features;
using FHS.Entities.Dto.Features;
using FHS.Entities.ListModel.Features;
using FHS.Entities.Model.Features;
using FHS.Interfaces.Services.Features;
using FHS.Tests.Api.Controllers.Base;
using FHS.Utilities.Common.Crud;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace FHS.Tests.Api.Controllers.Features
{
    public class ExpenseControllerUnitTest : BaseControllerUnitTests<ExpenseListModel, ExpenseModel, Expense, ExpenseController, IExpenseService>
    {
        public ExpenseControllerUnitTest() : base()
        {
            _controller = new ExpenseController(_loggerMock.Object, _serviceMock.Object);
        }
    }
}
