using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Linq;

namespace CommandLineArgumentParser.Tests
{
    [TestClass]
    public class ArgumentParserTests
    {
        private const string commandLineInput = @"/switch -option:""option value"" /switch2 -option2:""option value 2"" -option3:""option value 3"" /switch3";
        private static readonly ICommandLineInputProvider mockInputProvider = Substitute.For<ICommandLineInputProvider>();
        private CommandLineArgumentParser _sut = new CommandLineArgumentParser(mockInputProvider, new ArgumentParser(new OptionsParser()));

        [TestInitialize]
        public void TestInitialize()
        {
            mockInputProvider.GetCommandLineInput().Returns(commandLineInput);
        }

        [TestMethod]
        public void ParseResult_IsNotNull()
        {
            // Arrange

            // Act
            ParseResult result = _sut.GetParseResult();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ParseResult_CommandLineInput_AsExpected()
        {
            // Arrange

            // Act
            ParseResult result = _sut.GetParseResult();

            // Assert
            Assert.AreEqual(commandLineInput, result.CommandLineInput);
        }

        [TestMethod]
        public void CommandLineArgumentParser_Calls_GetCommandLineInput()
        {
            // Arrange

            // Act
            ParseResult result = _sut.GetParseResult();

            // Assert
            mockInputProvider.Received(1).GetCommandLineInput();
        }

        [TestMethod]
        public void ParseResult_Matches_Two_Arguments()
        {
            // Arrange

            // Act
            ParseResult result = _sut.GetParseResult();

            // Assert
            Assert.AreEqual(3, result.Arguments.Count());
        }

        [TestMethod]
        public void ParseResult_Argument1_CommandLineInput_AsExpected()
        {
            // Arrange

            // Act
            ParseResult result = _sut.GetParseResult();
            string commandLineInput = result.Arguments[0].CommandLineInput;

            // Assert
            Assert.AreEqual(@"switch -option:""option value""", commandLineInput);
        }

        [TestMethod]
        public void ParseResult_Argument2_CommandLineInput_AsExpected()
        {
            // Arrange

            // Act
            ParseResult result = _sut.GetParseResult();
            string commandLineInput = result.Arguments[1].CommandLineInput;

            // Assert
            Assert.AreEqual(@"switch2 -option2:""option value 2"" -option3:""option value 3""", commandLineInput);
        }

        [TestMethod]
        public void ParseResult_Argument1_Name_AsExpected()
        {
            // Arrange

            // Act
            ParseResult result = _sut.GetParseResult();
            string name = result.Arguments[0].Name;

            // Assert
            Assert.AreEqual("switch", name);
        }

        [TestMethod]
        public void ParseResult_Argument2_Name_AsExpected()
        {
            // Arrange

            // Act
            ParseResult result = _sut.GetParseResult();
            string name = result.Arguments[1].Name;

            // Assert
            Assert.AreEqual("switch2", name);
        }

        [TestMethod]
        public void ParseResult_Argument1_OptionCount_AsExpected()
        {
            // Arrange

            // Act
            ParseResult result = _sut.GetParseResult();
            int count = result.Arguments[0].Options.Count();

            // Assert
            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void ParseResult_Argument2_OptionCount_AsExpected()
        {
            // Arrange

            // Act
            ParseResult result = _sut.GetParseResult();
            int count = result.Arguments[1].Options.Count();

            // Assert
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void ParseResult_Argument3_OptionCount_AsExpected()
        {
            // Arrange

            // Act
            ParseResult result = _sut.GetParseResult();
            int count = result.Arguments[2].Options.Count();

            // Assert
            Assert.AreEqual(0, count);
        }
    }
}
