using PhaseShift.Library.Parsing.Exceptions;
using PhaseShift.Library.Parsing.Ini;
using System;
using System.Linq;
using Xunit;

namespace PhaseShift.Library.Parsing.Tests
{
    public class IniFormatParserTests
    {
        [Fact]
        public void Parse_SingleLineConfiguration_ReturnsValidOutput()
        {
            //Arrange
            var sut = new IniFormatParser();

            //Act
            var output = sut.Parse("key=value");

            //Assert
            Assert.Equal("key", output.First().Key);
            Assert.Equal("value", output.First().Value);
        }

        [Fact]
        public void Parse_WithCommentLine_IgnoresComment()
        {
            //Arrange
            var sut = new IniFormatParser();

            //Act
            var output = sut.Parse($"key=value{Environment.NewLine}!key=value");

            //Assert
            Assert.Single(output);
        }

        [Fact]
        public void Parse_WithSectionLine_IgnoresSection()
        {
            //Arrange
            var sut = new IniFormatParser();

            //Act
            var output = sut.Parse($"key=value{Environment.NewLine}[asjdsa]");

            //Assert
            Assert.Single(output);
        }

        [Fact]
        public void Parse_WithInvalidIniFile_ThrowsException()
        {
            //Arrange
            var sut = new IniFormatParser();

            //Act
            Action action = () => sut.Parse($"keasjdsa]");

            //Assert
            Assert.Throws<InvalidIniFileException>(action);
        }
    }
}
