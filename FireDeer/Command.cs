namespace FireDeer;

public abstract class Command
{
    public string name { get; protected set; } = "";
    public abstract bool Run(Queue<string> rawArgsQueue);
}