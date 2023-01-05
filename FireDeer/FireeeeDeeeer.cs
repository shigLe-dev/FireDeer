namespace FireDeer;

public class FireeeeDeeeer
{
    public List<Command> commands;

    public FireeeeDeeeer()
    {
        commands = new List<Command>();
    }

    public bool Run(string[] args)
    {
        var parser = new Parser(args);
        var arguments = parser.Parse();



        return false;
    }
}
