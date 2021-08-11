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

        [Fact]
        public void RemoveCharactersBetween_Should_ReturnInputString_WhenStartingOrEndingCharactersIsNotFound()
        {
            //Arrange
            string startingCharacters = "/*";
            string endingCharacters = "*/";
            string inputString = "a;lsdjfa;lskdf;alskdjf";

            //Act
            var result = _sut.RemoveCharactersBetween(inputString, startingCharacters, endingCharacters);

            //Assert
            Assert.Equal(inputString, result);
        }
    }
}
