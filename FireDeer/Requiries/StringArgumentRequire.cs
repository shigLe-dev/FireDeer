using FireDeer.Arguments;

namespace FireDeer.Requiries;

public class StringArgumentRequire : Require
{
    public override bool TryParse(Queue<string> rawArgs, out IArgument? result)
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