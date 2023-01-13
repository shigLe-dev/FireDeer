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
        Queue<string> rawArgsQueue = new Queue<string>(rawArgs);
        List<IArgument> args = new List<IArgument>();

        foreach (var require in requiries)
        {
            if (!require.TryParse(rawArgsQueue, out IArgument arg)) return false;
            else args.Add(arg);
        }

        action.Invoke(args.ToArray());

        return true;
    }
}
