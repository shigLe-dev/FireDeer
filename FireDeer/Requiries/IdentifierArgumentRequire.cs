using FireDeer.Arguments;

namespace FireDeer.Requiries;

public class IdentifierArgumentRequire : Require
{
    public string identifierName;

    public IdentifierArgumentRequire(string identifierName)
    {
        this.identifierName = identifierName;
    }

    public override bool TryParse(Queue<string> rawArgs, out IArgument? result)
    {
        result = null;

        if (rawArgs.TryDequeue(out string? rawArg) && rawArg != null)
        {
            IdentifierArgument strArg = new IdentifierArgument(rawArg);

            // 引数がidentifierNameと違うならfalseを返す
            if (strArg.name != identifierName) return false;
            result = strArg;
            return true;
        }

        return false;
    }
}