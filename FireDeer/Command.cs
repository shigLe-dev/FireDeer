using System.Collections.ObjectModel;

namespace FireDeer;

public class Command
{
    public event Action<Command> action;
    public readonly ReadOnlyCollection<Type> requireArguments;
    public readonly ReadOnlyCollection<(string, Type)> requireOptionArguments;

    public Command(Action<Command> action, Type[] requireArguments, (string, Type)[] requireOptionArguments)
    {
        this.action = action;
        this.requireArguments = requireArguments.AsReadOnly();
        this.requireOptionArguments = requireOptionArguments.AsReadOnly();
    }
}
