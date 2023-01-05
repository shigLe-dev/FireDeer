using FireDeer;

namespace FireDeerTest;

internal class Program
{
    static void Main(string[] args)
    {
        var cliParser = new CLIParser();

        var arguments = cliParser.Parse(args);

        foreach (var argument in arguments)
        {
            Console.WriteLine(argument.GetType().Name);
        }
    }
}