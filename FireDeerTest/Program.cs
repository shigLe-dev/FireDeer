using FireDeer;
using FireDeer.Requiries;
using FireDeer.Arguments;

namespace FireDeerTest;

internal class Program
{
    static void Main(string[] args)
    {
        Command command = new BaseCommandBuilder("testCommand")
            .SetAction(baseCommand =>
            {
                Console.WriteLine(hoge(baseCommand));

                string hoge(Command command)
                {
                    switch (command)
                    {
                        case BaseCommand baseCmd:
                            return string.Join('\n', baseCmd.subCommands.ToList().Select(s => hoge(s)));
                        case ActionCommand actionCmd:
                            return actionCmd.name + " " + string.Join(" ", actionCmd.requiries.Select(r => r.name));
                        default:
                            return "";
                    }
                }
            })
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
