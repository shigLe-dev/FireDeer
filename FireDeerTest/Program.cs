using FireDeer;

namespace FireDeerTest;

internal class Program
{
    static void Main(string[] args)
    {
        var cliParser = new Parser(args);

        var arguments = cliParser.Parse();

        foreach (var argument in arguments.arguments)
        {
            Console.WriteLine(argument.GetType().Name);
        }

        Console.WriteLine();

        foreach (var argument in arguments.optionArguments)
        {
            Console.WriteLine(argument.Key + " : " + argument.Value.literal);
        }
    }
}
