namespace CommandLineArgumentParser
{
    public class Argument
    {
        public string CommandLineInput { get; set; }

        public Argument(string commandLineInput)
        {
            this.CommandLineInput = commandLineInput;
        }
    }
}
