namespace FireDeer;

public class Command
{
    Require[] requiries;
    Action<IArgument[]> action;

    public Command(Require[] requiries, Action<IArgument[]> action)
    {
        this.requiries = requiries;
        this.action = action;
    }

    public bool Run(IArgument[] args)
    {
        bool ret = true;

        Queue<IArgument> argsQueue = new Queue<IArgument>(args);

        //全ての条件を満たしているか
        foreach (var require in requiries) ret &= require.Match(argsQueue);

        // 全ての条件を満たしているなら実行
        if (ret) action.Invoke(args);

        return ret;
    }
}
