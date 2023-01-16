namespace FireDeer;

public abstract class Command
{
    public string name { get; protected set; } = "";
    public string fullName => parent is null ? name : $"{parent.fullName} {name}";
    public Command? parent;
    public abstract bool Run(Queue<string> rawArgsQueue);
}