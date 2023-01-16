namespace FireDeer;

public abstract class Require
{
    public abstract string name { get; }
    public abstract bool TryParse(Queue<string> rawArgs, out IArgument arg);
}