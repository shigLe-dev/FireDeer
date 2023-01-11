namespace FireDeer.Arguments;

public class StringArgument : IArgument
{
    public string literal;

    public StringArgument(string literal)
    {
        this.literal = literal;
    }
}