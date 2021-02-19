using System.Collections.Generic;

namespace CommandLineArgumentParser
{
    public class Argument
    {
        public string CommandLineInput { get; set; }
        public string Name { get; set; }
        public IEnumerable<Option> Options { get; internal set; }

        public Argument(string commandLineInput)
        {
            this.CommandLineInput = commandLineInput;
            Options = new List<Option>();
        }
    }
}
