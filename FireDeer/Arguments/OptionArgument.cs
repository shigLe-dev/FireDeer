namespace FireDeer.Arguments;

internal record OptionArgument : Argument
{
    public readonly string argumentName;
    public readonly Argument argument;

    public OptionArgument(string argumentName, Argument argument)
    {
        this.argumentName = argumentName;
        this.argument = argument;
        literal = $"{argumentName} : {argument.literal}";
    }
}
