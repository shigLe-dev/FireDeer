namespace FireDeer.Arguments;

public class StringArgument : IArgument
{
    public string literal;

    public StringArgument(string literal)
    {
        this.literal = literal;
    }

    public static IArgument? Parse(Queue<string> rawArgs)
    {
        if (rawArgs.TryDequeue(out string? rawArg) && rawArg != null)
        {
            return new StringArgument(rawArg);
        }

        return null;
    }
}