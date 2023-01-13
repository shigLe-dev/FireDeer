using FireDeer;
using FireDeer.Requiries;

namespace FireDeerTest;

internal class Program
{
    static void Main(string[] args)
    {
        Command command = Command.CreateBaseCommand("testCommand",
            Command.CreateCommand("hoge",
                new Require[]
                {
                    new RequireInteger(),
                    new RequireInteger()
                },
                args =>
                {
                    args.ToList().ForEach(arg => Console.WriteLine(arg));
                }
            )
        );
        if (command.Run(args)) Console.WriteLine("Success");
        else Console.WriteLine("Failure");
    }
}
