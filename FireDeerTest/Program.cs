using FireDeer;
using FireDeer.Requiries;
using FireDeer.Arguments;

namespace FireDeerTest;

internal class Program
{
    static void Main(string[] args)
    {
        ICommand command = new BaseCommandBuilder("testCommand")
            .AddSubCommand(
                new ActionCommandBuilder("hoge")
                    .AddRequire(new RequireInteger())
                    .AddRequire(new RequireInteger())
                    .SetAction(args =>
                    {
                        IntegerArgument integerArgument1 = (IntegerArgument)args[0];
                        IntegerArgument integerArgument2 = (IntegerArgument)args[1];

                        Console.WriteLine(integerArgument1.bigInteger);
                        Console.WriteLine(integerArgument2.bigInteger);
                    })
                    .Build()
            )
            .AddSubCommand(
                new ActionCommandBuilder("hoge")
                    .AddRequire(new RequireInteger())
                    .SetAction(args =>
                    {
                        IntegerArgument value = (IntegerArgument)args[0];

                        Console.WriteLine(value.bigInteger);
                    })
                    .Build()
            )
            .Build();

        if (command.Run(new Queue<string>(args))) Console.WriteLine("Success");
        else Console.WriteLine("Failure");
    }
}
