using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Net.Http;

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
            var response = httpClient.GetAsync("https://your-api-endpoint").Result;
            // Process the response if needed
        }
    }
}
