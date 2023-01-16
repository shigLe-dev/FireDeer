using System.Collections.ObjectModel;

namespace FireDeer;

public class BaseCommand : Command
{
    public Action<BaseCommand>? action => _action;
    public ReadOnlyCollection<Command> subCommands => _subCommands.AsReadOnly();

    event Action<BaseCommand>? _action;
    readonly Command[] _subCommands;

    public BaseCommand(string name, Command[] subCommands, Action<BaseCommand>? action = null)
    {
        this.name = name;
        this._subCommands = subCommands;
        this._action = action;
    }

    public override bool Run(Queue<string> rawArgsQueue)
    {
        // 引数なしのアクションがnullじゃないなら実行する
        if (rawArgsQueue.Count == 0 && _action != null)
        {
            _action.Invoke(this);
            return true;
        }

        // subCommandにあるか
        foreach (var subCommand in _subCommands)
        {
            if (!rawArgsQueue.TryPeek(out string? rawArg)) continue;
            if (rawArg == null) continue;
            if (rawArg != subCommand.name) continue;

            Queue<string> subCommandRawArgs = new Queue<string>(rawArgsQueue);
            subCommandRawArgs.Dequeue();
            if (subCommand.Run(subCommandRawArgs)) return true;
        }

        foreach (var subCommand in _subCommands)
        {
            if (rawArgsQueue.TryPeek(out string? rawArg) && rawArg != null && rawArg == subCommand.name)
            {
                rawArgsQueue.Dequeue();
                if (subCommand.Run(rawArgsQueue)) return true;
            }
        }

        return false;
    }
}