using System.Numerics;

namespace FireDeer.Arguments;

public class IntegerArgument : IArgument
{
    public readonly BigInteger bigInteger;

    public IntegerArgument(BigInteger bigInteger)
    {
        this.bigInteger = bigInteger;
    }
}