using System;
using System.Linq;

namespace CommandLineArgumentParser
{
    public class ArgumentParser
    {
        private readonly ICommandLineInputProvider inputProvider;

        public ArgumentParser(ICommandLineInputProvider inputProvider)
        {
            this.inputProvider = inputProvider;
        }

        public ParseResult GetParseResult()
        {
            var result = new ParseResult();
            result.CommandLineInput = inputProvider.GetCommandLineInput();
            result.Arguments = result.CommandLineInput.Split("/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(i => new Argument(i.Trim()));
            return result;
        }
    }
}
