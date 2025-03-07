namespace AsynchronousProgramming;

public class Pfx
{
    public static int InvokeSumParallel()
    {
        int sum1 =0, sum2=0, sum3=0;
        try
        {
            Parallel.Invoke(
                () => sum1 = Sum1(),
                () => sum2 = Sum2(),
                () => sum3 = Sum3()
            );
        
            return sum1 + sum2 + sum3;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception thrown: {e.Message}");
        }

        return -1;
    }
    
    public static int InvokeSumAsync()
    {
        return Sum1() + Sum2() + Sum3();
    }

    private static int Sum1()
    {
        //throw new ArgumentException("Exception thrown on Sum1");
        Thread.Sleep(200);
        return 20;
    }

    private static int Sum2()
    {
        Thread.Sleep(300);
        return 20;
    }

    private static int Sum3()
    {
        Thread.Sleep(200);
        return 20;
    }
}