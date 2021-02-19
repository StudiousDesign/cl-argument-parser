using System.Collections.Generic;

namespace CommandLineArgumentParser
{
    public class ParseResult
    {
        public string CommandLineInput { get; set; }
        public List<Argument> Arguments { get; set; }

        public ParseResult()
        {
            Arguments = new List<Argument>();
        }
    }
}
