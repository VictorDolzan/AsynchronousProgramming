namespace AsynchronousProgramming;

public static class UnderlyingThread
{
    public static void Run()
    {
        // RunTaskAsForeground();
        // return;
        // var message = Guid.NewGuid().ToString();
        // var task = Task.Factory.StartNew((o) => 
        //     WhatsMyHome(message), CancellationToken.None, TaskCreationOptions.LongRunning
        // );
        // task.Wait();

        var task = Task.Factory.StartNew<string>(() => GetMessage());
        Console.WriteLine(task.Result);
    }

    private static string GetMessage()
    {
        return "Task return value right there";
    }

    private static void RunTaskAsForeground()
    {
        var tsc = new TaskCompletionSource<object>();
        new Thread(() =>
        {
            WhatsMyHome(String.Empty);
            tsc.SetResult(new object());
        }).Start();
        
        var t = tsc.Task;
        t.Wait();
    }

    private static void WhatsMyHome(string message)
    {
        var current = Thread.CurrentThread;
        var isThreadPoolThread = Thread.CurrentThread.IsThreadPoolThread;
        var isBackground = current.IsBackground;
        
        var threadType = isThreadPoolThread ? "ThreadPool" : "Custom";
        var threadKind = isBackground ? "Background" : "Foreground";
        
        // Console.WriteLine($"I am a thread type {threadType} thread in the {threadKind}");
        Console.WriteLine($"{message}");
    }
}