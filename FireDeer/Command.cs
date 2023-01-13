namespace FireDeer;

public class Command
{
    readonly string name;
    readonly Require[] requiries;
    event Action<IArgument[]> action;

    readonly Command[] subCommands;

    public Command(string name, Require[] requiries, Action<IArgument[]> action, params Command[] subCommands)
    {
        this.name = name;
        this.requiries = requiries;
        this.action = action;

        this.subCommands = subCommands;
    }

    public bool Run(string[] rawArgs)
    {
        return Run(this, rawArgs);
    }

    public static bool Run(Command command, string[] rawArgs)
    {
        Queue<string> rawArgsQueue = new Queue<string>(rawArgs);
        List<IArgument> args = new List<IArgument>();

        foreach (var require in command.requiries)
        {
            if (!require.TryParse(rawArgsQueue, out IArgument arg)) return false;
            else args.Add(arg);
        }

        command.action.Invoke(args.ToArray());

        return true;
    }
}
