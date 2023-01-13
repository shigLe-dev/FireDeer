namespace FireDeer;

public class ActionCommand : ICommand
{
    public string name { get; set; }
    readonly Require[] requiries;
    event Action<IArgument[]> action;

    public ActionCommand(string name, Require[] requiries, Action<IArgument[]> action)
    {
        this.name = name;
        this.requiries = requiries;
        this.action = action;
    }

    public bool Run(Queue<string> rawArgsQueue)
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
}
