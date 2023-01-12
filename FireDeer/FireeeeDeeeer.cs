using FireDeer.Requiries;
using System.Text;

namespace FireDeer;

public class FireeeeDeeeer
{
    readonly string[] rawArgs;
    readonly List<Command> commands;
    readonly string commandDescription;

    public FireeeeDeeeer(string[] rawArgs, string commandDescription, bool addHelp, params Command[] commands)
    {
        this.rawArgs = rawArgs;
        this.commands = commands.ToList();
        this.commandDescription = commandDescription;

        if (addHelp) AddHelpCommand();
    }

    public bool Run()
    {
        foreach (var command in commands)
        {
            if (command.TryRun(rawArgs)) return true;
        }

        return false;
    }

    public void AddHelpCommand()
    {
        this.commands.Add(new CommandBuilder()
            .AddRequire(new IdentifierArgumentRequire("help"))
            .SetAction(args =>
            {
                StringBuilder builder = new StringBuilder();

                builder.AppendLine(commandDescription);
                builder.AppendLine();
                builder.AppendLine("The commands are:");
                foreach (var command in commands)
                {
                    builder.AppendLine("        " + command.RequireDescription);
                }

                Console.WriteLine(builder.ToString());
            })
            .Build());
    }
}
