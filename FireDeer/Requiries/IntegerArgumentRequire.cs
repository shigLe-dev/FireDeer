using FireDeer.Arguments;
using System.Numerics;

namespace FireDeer.Requiries;

public class IntegerArgumentRequire : Require
{
    public override string description => "<integer>";

    public override bool TryParse(Queue<string> rawArgs, out IArgument? result)
    {
        result = null;

        if (rawArgs.TryDequeue(out string? rawArg) && rawArg != null)
        {
            if (!BigInteger.TryParse(rawArg, out BigInteger intresult)) return false;
            result = new IntegerArgument(intresult);
            return true;
        }

        return false;
    }
}