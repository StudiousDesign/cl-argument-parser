namespace CommandLineArgumentParser
{
    public interface IArgumentParser
    {
        Argument Parse(string commandLineInput);
    }
}
