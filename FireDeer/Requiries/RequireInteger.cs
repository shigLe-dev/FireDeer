using FireDeer.Arguments;
using System.Numerics;

namespace FireDeer.Requiries;

public class RequireInteger : Require
{
    public override bool TryParse(Queue<string> rawArgs, out IArgument arg)
    {
        arg = new ErrorArgument();

        // 引数が取得できるか
        if (!rawArgs.TryDequeue(out string? rawArg) || rawArg == null) return false;

        // 引数を整数にできるか
        if (!BigInteger.TryParse(rawArg, out BigInteger bigInteger)) return false;

        arg = new IntegerArgument(bigInteger);
        return true;
    }
}