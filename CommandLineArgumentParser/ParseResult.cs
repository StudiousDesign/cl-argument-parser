using System.Collections.Generic;

namespace CommandLineArgumentParser
{
    public class ParseResult
    {
        public string CommandLineInput { get; set; }
        public IEnumerable<Argument> Arguments { get; set; }
    }
}
