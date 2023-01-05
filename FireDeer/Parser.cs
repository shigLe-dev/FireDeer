using FireDeer.Arguments;
using System.Collections.ObjectModel;

namespace FireDeer;

public class Parser
{
    List<Func<Argument?>> argumentParseFunctions;
    string[] arguments;
    int position;
    string currentArgument
    {
        get
        {
            if (arguments.Length > position && 0 <= position) return arguments[position];
            else return "";
        }
    }

    public Parser(string[] arguments)
    {
        argumentParseFunctions = new List<Func<Argument?>>
        {
            ParseInt,
            ParseDecimal,
            ParseString
        };
        this.arguments = arguments;
    }

    public Argument[] Parse()
    {
        List<Argument> ret = new List<Argument>();

        while (true)
        {
            if (arguments.Length <= position) break;

            ret.Add(ParseArgument());
            Next();
        }

        return ret.ToArray();
    }

    public Argument ParseArgument()
    {
        foreach (var argumentParseFunction in argumentParseFunctions)
        {
            var ret = argumentParseFunction();
            if (ret != null) return ret;
        }

        return new NullArgument(currentArgument);
    }

    void Next()
    {
        position++;
    }

    #region ArgumentParseFunctions

    IntArgument? ParseInt()
    {
        if (int.TryParse(currentArgument, out int result)) return new IntArgument(result);
        return null;
    }

    StringArgument? ParseString()
    {
        return new StringArgument(currentArgument);
    }

    DecimalArgument? ParseDecimal()
    {
        if (float.TryParse(currentArgument, out float result)) return new DecimalArgument(result);
        return null;
    }

    #endregion
}
