using FireDeer;
using FireDeer.Requiries;

namespace FireDeerTest;

internal class Program
{
    static void Main(string[] args)
    {
        ICommand command = new BaseCommand("testCommand",
            new ActionCommand("hoge",
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
        if (command.Run(new Queue<string>(args))) Console.WriteLine("Success");
        else Console.WriteLine("Failure");
    }
}
