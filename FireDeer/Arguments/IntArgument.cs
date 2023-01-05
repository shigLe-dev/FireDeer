namespace FireDeer.Arguments;

internal class IntArgument : Argument
{
    public IntArgument(int literal)
    {
        this.literal = literal.ToString() ?? "";
    }
}
