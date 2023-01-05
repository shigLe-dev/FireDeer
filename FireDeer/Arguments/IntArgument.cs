﻿namespace FireDeer.Arguments;

internal class IntArgument : Argument
{
    public readonly int value;

    public IntArgument(int value)
    {
        this.value = value;

        literal = value.ToString();
    }
}
