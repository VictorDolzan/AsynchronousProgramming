namespace AsynchronousProgramming;

public class Cancellation
{
    public static void Cancel()
    {
        var cts = new CancellationTokenSource();
        var token = cts.Token;
        
        var task = RunAsync(token);
        Thread.Sleep(200);
        try
        {
            cts.Cancel();
            task.Wait();
        }
        catch (Exception)
        {
            Console.WriteLine($"State of task is {task.Status}");
        }
    }

    private static Task RunAsync(CancellationToken token)
    {
        return Task.Run(() =>
        {
            while (!token.IsCancellationRequested)
            {
                Thread.Sleep(70);
                Console.WriteLine("Not cancelled yet");
            }

            Console.WriteLine("Was cancelled");
            
            token.ThrowIfCancellationRequested();
            //or do
            // throw new OperationCanceledException("Cancelled", token);
        });
    }
}