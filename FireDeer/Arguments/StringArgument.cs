namespace FireDeer.Arguments;

public class StringArgument : IArgument
{
    public readonly string literal;

    public StringArgument(string literal)
    {
        this.literal = literal;
    }
}