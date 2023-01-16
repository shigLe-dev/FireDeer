using System.Collections.ObjectModel;

namespace FireDeer;

public class ActionCommand : Command
{
    public ReadOnlyCollection<Require> requiries => _requiries.AsReadOnly();
    public Action<IArgument[]> action => _action;

    readonly Require[] _requiries;
    event Action<IArgument[]> _action;

    public ActionCommand(string name, Require[] requiries, Action<IArgument[]> action)
    {
        this.name = name;
        this._requiries = requiries;
        this._action = action;
    }

    public override bool Run(Queue<string> rawArgsQueue)
    {
        // 引数が正しいか
        List<IArgument> args = new List<IArgument>();

        foreach (var require in _requiries)
        {
            if (!require.TryParse(rawArgsQueue, out IArgument arg)) return false;
            else args.Add(arg);
        }

        // 数は余ってないか
        if (rawArgsQueue.Count != 0) return false;

        _action.Invoke(args.ToArray());

        return true;
    }
}
