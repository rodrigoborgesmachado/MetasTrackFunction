﻿using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using Microsoft.Extensions.Hosting;

public static class ScheduledFunction
{
    [FunctionName("ScheduledFunction")]
    public static void Run(
        [TimerTrigger("0 0 1 * * *")] TimerInfo myTimer,
        ILogger log)
    {
        log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

        // Make an HTTP request to your API
        using (var httpClient = new HttpClient())
        {
            _ = httpClient.GetAsync("https://apisunsale.azurewebsites.net/api/Metas/RunProcess").Result;
            // Process the response if needed
        }
    }

    static async Task Main(string[] args)
    {
        var host = new HostBuilder()
            .ConfigureWebJobs(builder =>
            {
                builder.AddTimers();
            })
            .Build();

        using (host)
        {
            await host.RunAsync();
        }
    }
}
