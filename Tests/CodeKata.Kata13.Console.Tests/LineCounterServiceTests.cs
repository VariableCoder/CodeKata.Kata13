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
        [MemberData(nameof(GetTestDataForRemoveCharactersFunction))]
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

        [Theory]
        [MemberData(nameof(GetTestDataForCountNumberOfLinesFunction))]
        public void CountNumberOfLines_Should_ReturnTheRightNumberOfLines(string inputString, int expectedNumberOfLines)
        {
            //Act
            var result = _sut.GetNumberOfLines(inputString);

            //Assert
            Assert.Equal(expectedNumberOfLines, result);
        }

        public static TheoryData<string, string> GetTestDataForRemoveCharactersFunction()
        {
            return new TheoryData<string, string>
            {
                { "a;ldkjf/*a;lsdjf;asldfj", "a;ldkjf/*a;lsdjf;asldfj" },
                { "a;ldkjfa;ls*/djf;asldfj", "a;ldkjfa;ls*/djf;asldfj" },
                 { "asdfj/*;lsdjf;*/lsdkf", "asdfjlsdkf" }
            };
        }

        public static TheoryData<string, int> GetTestDataForCountNumberOfLinesFunction()
        {
            return new TheoryData<string, int>
            {
                { "a;ldkjf\n//ldfj\na;slfja/*a;slfj*/a;slkdjf\n;asdlfj;", 3 },
                { "a;ldkjf\n//ldfj\na;slfja/*a;slfj*/a;slkdjf\n;asdlfj;\n}\n}\n\n", 5 },
                {
                    @"/*****
                        * This is a test program with 5 lines of code
                        *  \/* no nesting allowed!
                        //*****//***/// Slightly pathological comment ending...
                        
                        public class Hello {
                            public static final void main(String [] args) { // gotta love Java
                                // Say hello
                                System./*wait*/out./*for*/println/*it*/(""Hello/*"");
                            }
                            
                        }", 5
                }
            };
        }
    }
}
