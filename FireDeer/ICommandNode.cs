namespace FireDeer;

public interface ICommand
{
    public string name { get; protected set; }
    public bool Run(Queue<string> rawArgsQueue);
}