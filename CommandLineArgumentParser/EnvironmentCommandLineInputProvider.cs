using System;

namespace CommandLineArgumentParser
{
    public class EnvironmentCommandLineInputProvider : ICommandLineInputProvider
    {
        public string GetCommandLineInput()
        {
            return string.Join("", Environment.GetCommandLineArgs());
        }
    }
}
