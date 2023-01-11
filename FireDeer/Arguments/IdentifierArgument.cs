namespace FireDeer.Arguments;

public class IdentifierArgument : IArgument
{
    public readonly string name;

    public IdentifierArgument(string name)
    {
        this.name = name;
    }
}