namespace FireDeer.Arguments;

internal class StringArgument : Argument
{
    public readonly string value;

    public StringArgument(string value)
    {
        this.value = value;

        this.literal = value;
    }
}
