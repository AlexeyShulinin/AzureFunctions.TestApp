using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FirstFunctions;

public static class CatInfoByTimeTrigger
{
    private static readonly HttpClient client = new HttpClient();
    
    [FunctionName("CatInfoByTimeTrigger")]
    public static async Task RunAsync([TimerTrigger("*/15 * * * * *")] TimerInfo myTimer, ILogger log)
    {
        var response = await client.GetFromJsonAsync<CatInfo>("https://catfact.ninja/fact");
        log.LogInformation($"Fact: {response?.Fact}");
    }
}