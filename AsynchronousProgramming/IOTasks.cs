﻿using System.Net;
using System.Threading.Channels;

namespace AsynchronousProgramming;

public static class IOTasks
{
    /// <summary>
    /// Load method
    /// </summary>
    public static void Load()
    {
        var task = Task.Factory.StartNew(() =>
        {
            return GetWebPage();
        });

        Console.WriteLine(task.Result);
    }

    /// <summary>
    /// Get page method
    /// </summary>
    /// <returns></returns>
    private static string GetWebPage()
    {
        var request = new HttpClient();
        request.BaseAddress = new Uri("https://www.google.com");
        
        var response = request.Send(new HttpRequestMessage());
        
        return response.Content.ReadAsStringAsync().Result;
    }
}