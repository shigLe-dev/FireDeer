namespace FireDeer;

public class BaseCommandBuilder
{
    string name;
    List<Command> subCommands;
    Action<BaseCommand>? action;

    public BaseCommandBuilder(string name)
    {
        this.name = name;
        subCommands = new List<Command>();
    }

    public BaseCommandBuilder SetName(string name)
    {
        this.name = name;
        return this;
    }

    public BaseCommandBuilder AddSubCommand(Command subCommand)
    {
        this.subCommands.Add(subCommand);
        return this;
    }

    public BaseCommandBuilder SetAction(Action<BaseCommand> action)
    {
        this.action = action;
        return this;
    }

    public BaseCommandBuilder AddAction(Action<BaseCommand> action)
    {
        this.action += action;
        return this;
    }

    public Command Build()
    {
        return new BaseCommand(name, subCommands.ToArray(), action);
    }
}