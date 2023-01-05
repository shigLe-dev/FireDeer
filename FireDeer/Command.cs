using FireDeer.Arguments;
using System.Collections.ObjectModel;

namespace FireDeer;

public class Command
{
    public event Action<Argument[]> action;
    public readonly ReadOnlyCollection<Type> requireArguments;
    public readonly ReadOnlyCollection<(string name, Type type)> requireOptionArguments;

    public Command(Action<Argument[]> action, Type[] requireArguments, (string name, Type type)[] requireOptionArguments)
    {
        this.action = action;
        this.requireArguments = requireArguments.AsReadOnly();
        this.requireOptionArguments = requireOptionArguments.AsReadOnly();
    }

    public bool Match(Argument[] arguments, Dictionary<string, Argument> optionArguments)
    {
        if (requireArguments.Count == arguments.Length) return false;

        bool ret = true;

        for (int i = 0; i < requireArguments.Count; i++)
        {

        }

        return ret;
    }
}
