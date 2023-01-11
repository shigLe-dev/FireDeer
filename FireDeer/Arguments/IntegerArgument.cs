using System.Numerics;

namespace FireDeer.Arguments;

public class IntegerArgument : IArgument
{
    public readonly BigInteger literal;

    public IntegerArgument(BigInteger literal)
    {
        this.literal = literal;
    }
}