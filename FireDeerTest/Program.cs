using FireDeer;

namespace FireDeerTest;

internal class Program
{
    static void Main(string[] args)
    {
        var cliParser = new Parser();

        var arguments = cliParser.Parse(args);

        foreach (var argument in arguments)
        {
            Console.WriteLine(argument.GetType().Name);
        }
    }
}
