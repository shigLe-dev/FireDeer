using FireDeer.Arguments;

namespace FireDeer.Requiries;

public class StringArgumentRequire : Require
{
    public override string description => "<string>";

    public override bool TryParse(Queue<string> rawArgs, out IArgument? result)
    {
        result = null;

        if (rawArgs.TryDequeue(out string? rawArg) && rawArg != null)
        {
            result = new StringArgument(rawArg);
            return true;
        }

        return false;
    }
}