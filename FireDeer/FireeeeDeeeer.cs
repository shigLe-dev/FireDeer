using FireDeer.Arguments;

namespace FireDeer;

public class FireeeeDeeeer
{
    string[] rawArgs;
    List<Command> commands;
    List<Func<Queue<string>, IArgument?>> argumentParseFunctions = new List<Func<Queue<string>, IArgument?>>()
    {
        StringArgument.Parse
    };

    public FireeeeDeeeer(string[] rawArgs, Command[] commands)
    {
        this.rawArgs = rawArgs;
        this.commands = commands.ToList();
    }

    public IArgument[] Parse()
    {
        List<IArgument> ret = new List<IArgument>(rawArgs.Length);
        Queue<string> rawArgsQueue = new Queue<string>(rawArgs);

        while (rawArgsQueue.TryPeek(out string? result))
        {
            IArgument? parsedArg = ParseArgument(rawArgsQueue);
            if (parsedArg != null) ret.Add(parsedArg);
        }

        return ret.ToArray();
    }

    IArgument? ParseArgument(Queue<string> rawArgsQueue)
    {
        foreach (var argumentParseFunction in argumentParseFunctions)
        {
            return argumentParseFunction(rawArgsQueue);
        }

        return null;
    }
}
