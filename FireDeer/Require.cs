using FireDeer.Arguments;

namespace FireDeer;

public abstract class Require
{
    public abstract bool Match(Queue<IArgument> argsQueue);

    public bool TryParse(Queue<string> rawArgs, out IArgument? result)
    {
        if (rawArgs.TryDequeue(out string? rawArg) && rawArg != null)
        {
            result = new StringArgument(rawArg);
            return true;
        }

        result = null;
        return false;
    }
}