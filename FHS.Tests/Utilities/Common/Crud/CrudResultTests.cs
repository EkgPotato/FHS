using FHS.Utilities.Common.Crud;
using FluentAssertions;
using Xunit;

namespace FHS.Tests.Utilities.Common.Crud
{
    public class CrudResultTests
    {
        [Fact]
        public void CrudResult_Succeed_ReturnTrue()
        {
            //Arrange 
            var test = new CrudResult();

            //Act 
            var result = test.Succeed();

            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void CrudResult_Succeed_ReturnFalse()
        {
            //Arrange 
            var test = new CrudResult();

            //Act 
            test.AddMessage("test message");
            var result = test.Succeed();

            //Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void CrudResult_ShouldAddMessageToList()
        {
            //Arrange 
            var test = new CrudResult();

            //Act 
            test.AddMessage("test message");

            //Assert
            test.Messages.Should().HaveCount(1);
        }

        [Fact]
        public void CrudResult_ShouldBeInitializedEmptyList()
        {
            //Arrange 
            var test = new CrudResult();

            //Assert
            test.Messages.Should().NotBeNull();
            test.Messages.Should().BeEmpty();
        }
    }
}
