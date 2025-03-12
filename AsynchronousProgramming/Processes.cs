using System.Diagnostics;

namespace AsynchronousProgramming;

public static class Processes
{
    public static void Demo()
    {
        #region Class Block

        // var app = new Process()
        // {
        //     StartInfo =
        //     {
        //         FileName = "notepad.exe",
        //         Arguments = "D:\\Programação\\HelloWorld.txt"
        //     }
        // };
        //
        // app.Start();
        //
        // app.PriorityClass = ProcessPriorityClass.RealTime;
        //
        // Console.WriteLine("Real time execution");

        #endregion

        #region Exercise Block
        
        var app = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                // FileName = "C:\\Users\\victo\\AppData\\Local\\Programs\\Hyper\\hyper.exe",
                // FileName = "cmd.exe",
                FileName = "C:\\Program Files\\Git\\bin\\bash.exe",
                Arguments = $"",
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = false
            }
        };
        
        app.Start();
        app.PriorityClass = ProcessPriorityClass.RealTime;
        
        Thread.Sleep(2000);
        
        app.StandardInput.WriteLine("echo Hello World");
        app.StandardInput.WriteLine("hyper .");
        Thread.Sleep(2000);
        app.StandardInput.Flush();

        #endregion
    }
}