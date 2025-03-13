using System.Diagnostics;

namespace AsynchronousProgramming;

public static class Threads
{
    public static void Run()
    {
        var thread1 = new Thread(() => Print());
        thread1.Start();
        
        Console.ReadLine();
    }

    private static void Print()
    {
        Console.WriteLine($"Hello world from the first thread!");
    }
}