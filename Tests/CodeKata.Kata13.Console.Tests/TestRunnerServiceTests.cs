using CodeKata.Kata13.Console.Services;
using Moq;
using Xunit;

namespace CodeKata.Kata13.Console.Tests
{
    public class TestRunnerServiceTests
    {
        private readonly ITestRunnerService _sut;
        private readonly Mock<ILineCountingService> _lineCountingServiceMock;
        public TestRunnerServiceTests()
        {
            _lineCountingServiceMock = new Mock<ILineCountingService>();
            _sut = new TestRunnerService(_lineCountingServiceMock.Object);
        }

        [Fact]
        public void RunTestScenario_Should_CallTheLineCountingService_ExactlyOnce()
        {
            //Arrange
            var numberOfLines = 2;
            _lineCountingServiceMock.Setup(x => x.GetNumberOfLines(It.IsAny<string>()))
                .Returns(numberOfLines);

            //Act
            var result = _sut.RunTestScenario(1);

            //Assert
            Assert.Equal(numberOfLines, result);
            _lineCountingServiceMock.Verify(x => x.GetNumberOfLines(It.IsAny<string>()), Times.Once);
        }
    }
}
