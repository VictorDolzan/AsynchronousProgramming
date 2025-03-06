namespace AsynchronousProgramming;

public class Combinators
{
    public static async Task RunTask()
    {
        var winner = await Task.WhenAny(Delay1(), Delay2(), Delay3());
        Console.WriteLine($"Race is over");
        Console.WriteLine(winner.Result);
        
        var task = Task.WhenAll(Delay1(), Delay2(), Delay3());

        try
        {
            (await task).ToList().ForEach(item => Console.WriteLine(item));
            // var result = await task;
            // foreach (var item in result)
            // {
            //     Console.WriteLine(item);
            // }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    private static async Task<int> Delay1() { await Task.Delay(1000); return 1; }
    private static async Task<int> Delay2() { await Task.Delay(2000); return 2; }
    private static async Task<int> Delay3() { await Task.Delay(3000); return 3; }
}