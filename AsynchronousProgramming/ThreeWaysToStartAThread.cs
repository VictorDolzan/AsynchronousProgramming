namespace AsynchronousProgramming;

public static class ThreeWaysToStartAThread
{
    public static void RunTasks()
    {
        var task = new Task(() => Console.WriteLine("From a task!"));
        
        task.Start();

        // Console.ReadKey();
        task.Wait();
    }

    public static void Run()
    {
        #region TaskStart

        // var task = new Task(() => Console.WriteLine("Task start()!"));
        // task.Start();
        //
        // task.Wait();

        #endregion

        #region TaskFactory

        // var taskFactory = new TaskFactory().StartNew(() => Console.WriteLine("TaskFactory!"));
        //var taskFactory = Task.Factory.StartNew(() => Console.WriteLine("From Task factory!"));
        // taskFactory.Wait();

        #endregion

        #region TaskRun

        var task = Task.Run(() => Console.WriteLine("From Task.Run!"));
        task.Wait();

        #endregion
    }
}