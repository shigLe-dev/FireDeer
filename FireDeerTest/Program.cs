using FireDeer;
using FireDeer.Requiries;

namespace FireDeerTest;

internal class Program
{
    static void Main(string[] args)
    {
        ICommand command = new BaseCommand("testCommand",
            new ActionCommandBuilder("hoge2")
                .AddRequire(new RequireInteger())
                .AddRequire(new RequireInteger())
                .SetAction(args => { args.ToList().ForEach(arg => Console.WriteLine(arg)); }),
            new ActionCommandBuilder("hoge")
                .AddRequire(new RequireInteger())
                .SetAction(args => { args.ToList().ForEach(arg => Console.WriteLine(arg)); })
        );
        if (command.Run(new Queue<string>(args))) Console.WriteLine("Success");
        else Console.WriteLine("Failure");
    }
}
