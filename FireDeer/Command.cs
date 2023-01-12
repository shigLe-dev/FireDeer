namespace FireDeer;

public class Command
{
    Require[] requiries;
    Action<IArgument[]> action;
    public string RequireDescription => string.Join(" ", requiries.Select(r => { return r.description; }));

    public Command(Require[] requiries, Action<IArgument[]> action)
    {
        this.requiries = requiries;
        this.action = action;
    }

    public bool TryRun(string[] rawArgs)
    {
        Queue<string> rawArgsQueue = new Queue<string>(rawArgs);
        List<IArgument> args = new List<IArgument>();

        // 全ての条件を満たしているか
        foreach (var require in requiries)
        {
            bool parseSucess = require.TryParse(rawArgsQueue, out IArgument? result);

            // パースに失敗しているなら条件確認を中断して返す
            if (!parseSucess) return false;
            if (result == null) return false;

            // argsに追加
            args.Add(result);
        }

        // queueにあまりがないか
        if (rawArgsQueue.Count != 0) return false;

        // 全ての条件を満たしているなら実行
        action.Invoke(args.ToArray());

        return true;
    }
}
