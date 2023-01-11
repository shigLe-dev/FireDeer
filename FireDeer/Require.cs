namespace FireDeer;

public abstract class Require
{
    public abstract bool Match(Queue<IArgument> argsQueue);
}