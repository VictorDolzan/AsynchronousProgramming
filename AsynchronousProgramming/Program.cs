// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using AsynchronousProgramming;

#region ThreeWaysToStartAThread

// ThreeWaysToStartAThread.RunTask();

#endregion

#region UnderlyingThread

// UnderlyingThread.RunTask();

#endregion

#region Load

// IOTasks.Load();

#endregion

#region TasksRelationship

// TasksRelationship.Nested();

#endregion

#region Cancellation

// Cancellation.Cancel();

#endregion

#region Combinators

// await Combinators.RunTask();

#endregion

#region Pfx

var totalTime = new Stopwatch();
totalTime.Start();
var result = Pfx.InvokeSumParallel();
totalTime.Stop();
Console.WriteLine($"Result was {result}. The operation took {totalTime.ElapsedMilliseconds} ms");

#endregion