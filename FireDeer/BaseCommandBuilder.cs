namespace FireDeer;

public class BaseCommandBuilder
{
    string name;
    List<ICommand> subCommands;

    public BaseCommandBuilder(string name)
    {
        this.name = name;
        subCommands = new List<ICommand>();
    }

    public BaseCommandBuilder SetName(string name)
    {
        this.name = name;
        return this;
    }

    public BaseCommandBuilder AddSubCommand(ICommand subCommand)
    {
        this.subCommands.Add(subCommand);
        return this;
    }

    public ICommand Build()
    {
        return new BaseCommand(name, subCommands.ToArray());
    }
}