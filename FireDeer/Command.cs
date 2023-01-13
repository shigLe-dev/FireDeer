namespace FireDeer;

public class Command
{
    readonly string name;
    readonly Require[] requiries;
    event Action<IArgument[]> action;
    bool isBase;

    readonly Command[] subCommands;

    Command(bool isBase, string name, Require[] requiries, Action<IArgument[]> action, params Command[] subCommands)
    {
        this.isBase = isBase;
        this.name = name;
        this.requiries = requiries;
        this.action = action;

        this.subCommands = subCommands;
    }

    public bool Run(string[] rawArgs)
    {
        if (isBase) return RunBase(new Queue<string>(rawArgs));
        else return RunCommand(new Queue<string>(rawArgs));
    }

    bool RunCommand(Queue<string> rawArgsQueue)
    {
        // 引数が正しいか
        List<IArgument> args = new List<IArgument>();

        foreach (var require in requiries)
        {
            if (!require.TryParse(rawArgsQueue, out IArgument arg)) return false;
            else args.Add(arg);
        }

        // 数は余ってないか
        if (rawArgsQueue.Count != 0) return false;

        action.Invoke(args.ToArray());

        return true;
    }

    bool RunBase(Queue<string> rawArgsQueue)
    {
        // subCommandにあるか
        foreach (var subCommand in subCommands)
        {
            if (rawArgsQueue.TryPeek(out string? rawArg) && rawArg != null && rawArg == subCommand.name)
            {
                rawArgsQueue.Dequeue();
                if (subCommand.Run(rawArgsQueue.ToArray())) return true;
            }
            else continue;
        }

        return false;
    }

    public static Command CreateBaseCommand(string name, params Command[] subCommands)
        => new Command(true, name, new Require[0], args => { }, subCommands);

    public static Command CreateCommand(string name, Require[] requiries, Action<IArgument[]> action)
        => new Command(false, name, requiries, action);
}
