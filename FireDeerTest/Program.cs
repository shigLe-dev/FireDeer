using FireDeer;

namespace FireDeerTest;

internal class Program
{
    static void Main(string[] args)
    {
        Command command = new Command("testCommand", new Require[0], args => { });

        if (command.Run(args)) Console.WriteLine("Success");
        else Console.WriteLine("Failure");
    }
}
