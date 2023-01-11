using FireDeer;

namespace FireDeerTest;

internal class Program
{
    static void Main(string[] args)
    {
        FireeeeDeeeer fireeeeDeeeer = new FireeeeDeeeer(args, new Command[] { });

        foreach (var arg in fireeeeDeeeer.Parse())
        {
            Console.WriteLine(arg.GetType().Name);
        }
    }
}
