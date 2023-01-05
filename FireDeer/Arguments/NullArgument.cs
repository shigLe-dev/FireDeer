namespace FireDeer.Arguments;

public record NullArgument : Argument
{
    public NullArgument(string literal)
    {
        this.literal = literal;
    }
}
