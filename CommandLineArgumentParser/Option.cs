namespace CommandLineArgumentParser
{
    public class Option
    {
        public string CommandLineInput { get; set; }

        public Option(string commandLineInput)
        {
            CommandLineInput = commandLineInput;
        }
    }
}
