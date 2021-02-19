using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Linq;

namespace CommandLineArgumentParser.Tests
{
    [TestClass]
    public class ArgumentParserTests
    {
        private const string commandLineInput = @"/switch -option:""option value"" /switch2 -option2:""option value 2""";
        private readonly ICommandLineInputProvider mockInputProvider = Substitute.For<ICommandLineInputProvider>();

        [TestInitialize]
        public void TestInitialize()
        {
            mockInputProvider.GetCommandLineInput().Returns(commandLineInput);
        }

        [TestMethod]
        public void ParseResult_IsNotNull()
        {
            // Arrange
            var sut = new ArgumentParser(mockInputProvider);

            // Act
            ParseResult result = sut.GetParseResult();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ParseResult_CommandLineInput_AsExpected()
        {
            // Arrange
            var sut = new ArgumentParser(mockInputProvider);

            // Act
            ParseResult result = sut.GetParseResult();

            // Assert
            Assert.AreEqual(commandLineInput, result.CommandLineInput);
        }

        [TestMethod]
        public void ArgumentParser_Calls_GetCommandLineInput()
        {
            // Arrange
            var sut = new ArgumentParser(mockInputProvider);

            // Act
            ParseResult result = sut.GetParseResult();

            // Assert
            mockInputProvider.Received(1).GetCommandLineInput();
        }

        [TestMethod]
        public void ParseResult_Matches_Two_Arguments()
        {
            // Arrange
            var sut = new ArgumentParser(mockInputProvider);

            // Act
            ParseResult result = sut.GetParseResult();

            // Assert
            Assert.AreEqual(2, result.Arguments.Count());
        }

        [TestMethod]
        public void ParseResult_Argument1_CommandLineInput_AsExpected()
        {
            // Arrange
            var sut = new ArgumentParser(mockInputProvider);

            // Act
            ParseResult result = sut.GetParseResult();
            string commandLineInput = result.Arguments.First().CommandLineInput;

            // Assert
            Assert.AreEqual(@"switch -option:""option value""", commandLineInput);
        }

        [TestMethod]
        public void ParseResult_Argument2_CommandLineInput_AsExpected()
        {
            // Arrange
            var sut = new ArgumentParser(mockInputProvider);

            // Act
            ParseResult result = sut.GetParseResult();
            string commandLineInput = result.Arguments.Last().CommandLineInput;

            // Assert
            Assert.AreEqual(@"switch2 -option2:""option value 2""", commandLineInput);
        }
    }
}
