namespace FireDeer;

public class FireeeeDeeeer
{
    string[] rawArgs;
    List<Command> commands;

    public FireeeeDeeeer(string[] rawArgs, params Command[] commands)
    {
        this.rawArgs = rawArgs;
        this.commands = commands.ToList();
    }

    public bool Run()
    {
        foreach (var command in commands)
        {
            if (command.TryRun(rawArgs)) return true;
        }

        return false;
    }
}
