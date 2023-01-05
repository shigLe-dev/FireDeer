using FireDeer;

namespace FireDeerTest;

internal class Program
{
    static void Main(string[] args)
    {
        var cliParser = new Parser(args);

        var arguments = cliParser.Parse();

        foreach (var argument in arguments)
        {
            Console.WriteLine(argument.GetType().Name);
        }
    }
}
