using CodeKata.Kata13.Console.Services;
using System;
using Xunit;

namespace CodeKata.Kata13.Console.Tests
{
    public class LineCounterServiceTests
    {
        private ILineCountingService _sut;
        public LineCounterServiceTests()
        {
            _sut = new LineCountingService(); 
        }

        [Fact]
        public void IsValidLine_Should_ReturnFalse_WhenLineIsEmptyString()
        {
            //Arrange
            string line = string.Empty;

            //Act
            var result = _sut.IsValidLine(line);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void IsValidLine_Should_ReturnFalse_WhenLineStartsWithDoubleForwardSlash()
        {
            //Arrange
            string line = "//a;sldkfja;sldkjfa;sdlkjf";

            //Act
            var result = _sut.IsValidLine(line);

            //Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData("a;ldkjf/*a;lsdjf;asldfj", "a;ldkjf/*a;lsdjf;asldfj")]
        [InlineData("a;ldkjfa;ls*/djf;asldfj", "a;ldkjfa;ls*/djf;asldfj")]
        [InlineData("asdfj/*;lsdjf;*/lsdkf", "asdfjlsdkf")]
        public void RemoveCharactersBetween_Should_ReturnInputString_WhenStartingOrEndingCharactersIsNotFound(string inputString, string outputString)
        {
            //Arrange
            string startingCharacters = "/*";
            string endingCharacters = "*/";

            //Act
            var result = _sut.RemoveCharactersBetween(inputString, startingCharacters, endingCharacters);

            //Assert
            Assert.Equal(outputString, result);
        }
    }
}
