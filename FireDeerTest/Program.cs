using FireDeer;
using FireDeer.Requiries;

namespace FireDeerTest;

internal class Program
{
    static void Main(string[] args)
    {
        FireeeeDeeeer fireeeeDeeeer = new FireeeeDeeeer(args, "firedeerのテスト用コマンド", true,
            new CommandBuilder()
                .AddRequire(new StringArgumentRequire())
                .AddRequire(new IdentifierArgumentRequire("foo"))
                .AddRequire(new IntegerArgumentRequire())
                .SetAction(args => { foreach (var arg in args) Console.WriteLine(arg.GetType().Name); })
                .Build()
        );

        if (fireeeeDeeeer.Run()) Console.WriteLine("成功");
        else Console.WriteLine("失敗");
    }
}
