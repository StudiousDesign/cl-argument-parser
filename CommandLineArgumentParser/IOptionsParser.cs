using System.Collections.Generic;

namespace CommandLineArgumentParser
{
    public interface IOptionsParser
    {
        IEnumerable<Option> Parse(string commandLineInput);
    }
}
