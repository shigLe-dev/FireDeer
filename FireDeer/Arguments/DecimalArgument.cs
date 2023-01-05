namespace FireDeer.Arguments;

public record DecimalArgument : Argument
{
    public readonly float value;

    public DecimalArgument(float value)
    {
        this.value = value;

        literal = value.ToString();
    }
}
