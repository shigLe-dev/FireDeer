namespace FireDeer;

public class BaseCommand : ICommand
{
    public string name { get; set; }

    readonly ICommand[] subCommands;

    public BaseCommand(string name, params ICommand[] subCommands)
    {
        this.name = name;
        this.subCommands = subCommands;
    }

    public bool Run(Queue<string> rawArgsQueue)
    {
        // subCommandにあるか
        foreach (var subCommand in subCommands)
        {
            if (!rawArgsQueue.TryPeek(out string? rawArg)) continue;
            if (rawArg == null) continue;
            if (rawArg != subCommand.name) continue;

            Queue<string> subCommandRawArgs = new Queue<string>(rawArgsQueue);
            subCommandRawArgs.Dequeue();
            if (subCommand.Run(subCommandRawArgs)) return true;
        }

        foreach (var subCommand in subCommands)
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