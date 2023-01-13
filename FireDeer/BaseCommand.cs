namespace FireDeer;

public class BaseCommand : ICommand
{
    public string name { get; set; }

    readonly ActionCommand[] subCommands;

    public BaseCommand(string name, params ActionCommand[] subCommands)
    {
        this.name = name;
        this.subCommands = subCommands;
    }

    public bool Run(Queue<string> rawArgsQueue)
    {
        // subCommandにあるか
        foreach (var subCommand in subCommands)
        {
            if (rawArgsQueue.TryPeek(out string? rawArg) && rawArg != null && rawArg == subCommand.name)
            {
                rawArgsQueue.Dequeue();
                if (subCommand.Run(rawArgsQueue)) return true;
            }
            else continue;
        }

        return false;
    }
}