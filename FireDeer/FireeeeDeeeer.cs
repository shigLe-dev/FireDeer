using FireDeer.Arguments;

namespace FireDeer;

public class FireeeeDeeeer
{
    string[] rawArgs;
    List<Command> commands;

    public FireeeeDeeeer(string[] rawArgs, Command[] commands)
    {
        this.rawArgs = rawArgs;
        this.commands = commands.ToList();
    }

    public IArgument[] Parse()
    {

    }
}
