namespace AsynchronousProgramming;

public class TasksRelationship
{
    public static void Nested()
    {
        var taskOne = Task.Factory.StartNew(() =>
        {
            Console.WriteLine("TaskOne");
            var nestedTask = Task.Factory.StartNew(() =>
            {
                Thread.Sleep(200);
                Console.WriteLine("Nested Task");
            }, TaskCreationOptions.AttachedToParent);
        });
        
        taskOne.Wait();
        Continue();
    }

    internal static void Continue()
    {
        // var first_task = new Task(() => Console.WriteLine("From frist task"));
        var first_task = new Task(() => throw new Exception("Some exception"));

        var completionHandler = first_task.ContinueWith(t =>
            Console.WriteLine("From first task continued"), TaskContinuationOptions.OnlyOnRanToCompletion);
        
        var errorHandler = first_task.ContinueWith(t => 
            Console.WriteLine("First task faulted"), TaskContinuationOptions.OnlyOnFaulted);
        
        first_task.Start();
    }
}