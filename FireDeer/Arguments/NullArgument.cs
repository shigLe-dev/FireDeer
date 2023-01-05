namespace FireDeer.Arguments;

internal record NullArgument : Argument
{
    public NullArgument(string literal)
    {
        this.literal = literal;
    }
}
