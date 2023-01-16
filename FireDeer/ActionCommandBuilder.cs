namespace FireDeer;

public class ActionCommandBuilder
{
    string name;
    List<Require> requiries = new List<Require>();
    event Action<IArgument[]> action = args => { };

    public ActionCommandBuilder(string name)
    {
        this.name = name;
    }

    public ActionCommandBuilder SetName(string name)
    {
        this.name = name;
        return this;
    }

    public ActionCommandBuilder AddRequire(Require require)
    {
        this.requiries.Add(require);
        return this;
    }

    public ActionCommandBuilder SetAction(Action<IArgument[]> action)
    {
        this.action = action;
        return this;
    }

    public ActionCommandBuilder AddAction(Action<IArgument[]> action)
    {
        this.action += action;
        return this;
    }

    public Command Build()
    {
        return new ActionCommand(name, requiries.ToArray(), action);
    }
}