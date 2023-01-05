namespace FireDeer.Arguments;

internal class DecimalArgument : Argument
{
    public readonly float value;

    public DecimalArgument(float value)
    {
        this.value = value;

        literal = value.ToString();
    }
}
