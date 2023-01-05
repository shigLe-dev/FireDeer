using FireDeer.Arguments;
using System.Collections.ObjectModel;

namespace FireDeer;

public class Parser
{
    public ReadOnlyCollection<Command> commands => _commands.AsReadOnly();

    List<Command> _commands = new List<Command>();
    List<Func<string, Argument?>> argumentParseFunctions;

    public Parser()
    {
        argumentParseFunctions = new List<Func<string, Argument?>>
        {
            ParseInt,
            ParseDecimal,
            ParseString
        };
    }

    public Argument[] Parse(string[] arguments)
    {
        List<Argument> ret = new List<Argument>();

        foreach (var argument in arguments)
        {
            ret.Add(ParseArgument(argument));
        }

        return ret.ToArray();
    }

    public Argument ParseArgument(string argument)
    {
        foreach (var argumentParseFunction in argumentParseFunctions)
        {
            var ret = argumentParseFunction(argument);
            if (ret != null) return ret;
        }

        return new NullArgument(argument);
    }

    #region ArgumentParseFunctions

    IntArgument? ParseInt(string argument)
    {
        if (int.TryParse(argument, out int result)) return new IntArgument(result);
        return null;
    }

    StringArgument? ParseString(string argument)
    {
        return new StringArgument(argument);
    }

    DecimalArgument? ParseDecimal(string argument)
    {
        if (float.TryParse(argument, out float result)) return new DecimalArgument(result);
        return null;
    }

    #endregion
}
