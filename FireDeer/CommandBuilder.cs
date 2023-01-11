namespace FireDeer;

public class CommandBuilder
{
    List<Require> requiries = new List<Require>();
    event Action<IArgument[]> action = arg => { };

    public CommandBuilder AddRequire(Require require)
    {
        requiries.Add(require);
        return this;
    }

    public CommandBuilder SetAction(Action<IArgument[]> action)
    {
        this.action = action;
        return this;
    }

    public CommandBuilder AddAction(Action<IArgument[]> action)
    {
        this.action += action;
        return this;
    }

    public Command Build()
    {
        return new Command(requiries.ToArray(), action);
    }
}