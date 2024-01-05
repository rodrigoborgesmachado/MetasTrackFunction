using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Net.Http;

namespace FunctionAppSunSale
{
    public static class ScheduledFunction
    {
        [FunctionName("ScheduledFunction")]
        public static void Run(
        [TimerTrigger("0 31 12 * * *")] TimerInfo myTimer,
        ILogger log)
        {
            Console.WriteLine("Calling process");
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            try
            {
                // Make an HTTP request to your API
                using (var httpClient = new HttpClient())
                {
                    _ = httpClient.GetAsync("https://apisunsale.azurewebsites.net/api/Metas/RunProcess").Result;
                    // Process the response if needed
                }
            }
            catch (Exception ex)
            {
                log.LogInformation($"Error: {ex.Message}");
            }
        }
    }
}
