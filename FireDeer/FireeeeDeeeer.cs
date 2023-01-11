namespace FireDeer;

public class FireeeeDeeeer
{
    string[] rawArgs;
    List<Command> commands;
    List<Func<Queue<string>, IArgument?>> argumentParseFunctions = new List<Func<Queue<string>, IArgument?>>()
    {

    };

    public FireeeeDeeeer(string[] rawArgs, Command[] commands)
    {
        this.rawArgs = rawArgs;
        this.commands = commands.ToList();
    }

    public IArgument[] Parse()
    {
        List<IArgument> ret = new List<IArgument>(rawArgs.Length);
        Queue<string> rawArgsQueue = new Queue<string>(rawArgs);

        foreach (var argumentParseFunction in argumentParseFunctions)
        {
            // パースする
            IArgument? parsedArg = argumentParseFunction(rawArgsQueue);

            // nullならパースできてないので次に行く
            if (parsedArg == null) continue;

            // 返り値に追加
            ret.Add(parsedArg);
        }

        return ret.ToArray();
    }
}
