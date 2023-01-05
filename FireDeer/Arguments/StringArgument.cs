namespace FireDeer.Arguments;

public record StringArgument : Argument
{
    public readonly string value;

    public StringArgument(string value)
    {
        this.value = value;

        this.literal = value;
    }
}
