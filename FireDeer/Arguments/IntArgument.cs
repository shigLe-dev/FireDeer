﻿namespace FireDeer.Arguments;

public record IntArgument : Argument
{
    public readonly int value;

    public IntArgument(int value)
    {
        this.value = value;

        literal = value.ToString();
    }
}
