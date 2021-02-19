using System;
using System.Collections.Generic;

namespace CommandLineArgumentParser
{
    public class OptionsParser : IOptionsParser
    {
        public IEnumerable<Option> Parse(string commandLineInput)
        {
            var results = new List<Option>();
            foreach (var commandLineOptionInput in commandLineInput.Substring(commandLineInput.IndexOf('-')).Split("-".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
            {
                results.Add(new Option(commandLineOptionInput));
            }
            return results;
        }
    }
}
