using System.Linq;

namespace CommandLineArgumentParser
{
    public class ArgumentParser : IArgumentParser
    {
        private readonly IOptionsParser optionsParser;

        public ArgumentParser(IOptionsParser optionsParser)
        {
            this.optionsParser = optionsParser;
        }

        public Argument Parse(string commandLineInput)
        {
            string[] argumentParts = commandLineInput.Split(' ');
            Argument result = new Argument(commandLineInput);
            result.Name = argumentParts[0];

            if (argumentParts.Count() > 1)
                result.Options = optionsParser.Parse(commandLineInput);

            return result;
        }
    }
}
