using FireDeer;
using FireDeer.Requiries;

namespace FireDeerTest;

internal class Program
{
    static void Main(string[] args)
    {
        FireeeeDeeeer fireeeeDeeeer = new FireeeeDeeeer(args, new Command[] {
            new Command(
                new Require[]{
                    new StringArgumentRequire()
                },
                args => {
                    foreach (var arg in args)
                    {
                        Console.WriteLine(arg.GetType().Name);
                    }
                }
            )
        });

        if (fireeeeDeeeer.Run()) Console.WriteLine("成功");
        else Console.WriteLine("失敗");
    }
}
