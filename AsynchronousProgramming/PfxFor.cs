namespace AsynchronousProgramming;

public class PfxFor
{
    public static void Sync()
    {
        for (int i = 0; i < 10; i++)
        {
            DoWait(i);
        }
    }

    private static void DoWait(int i)
    {
        Thread.Sleep(i * 10);
    }

    public static void Para() => Parallel.For(0, 10, index => Decorate(index, DoWait));

    private static void Decorate(int index, Action<int> doWait)
    {
        Console.WriteLine($"Next index: {index}");
        doWait(index);
    }
}