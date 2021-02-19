using System;
using System.Linq;

namespace CommandLineArgumentParser
{
    public class CommandLineArgumentParser
    {
        private readonly ICommandLineInputProvider inputProvider;
        private readonly IArgumentParser argumentParser;

        public CommandLineArgumentParser(ICommandLineInputProvider inputProvider, IArgumentParser argumentParser)
        {
            this.inputProvider = inputProvider;
            this.argumentParser = argumentParser;
        }

        public ParseResult GetParseResult()
        {
            var result = new ParseResult();
            result.CommandLineInput = inputProvider.GetCommandLineInput();
            result.Arguments = result.CommandLineInput.Split("/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(i => argumentParser.Parse(i.Trim())).ToList();
            return result;
        }
    }
}
