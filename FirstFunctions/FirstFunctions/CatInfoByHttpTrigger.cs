using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FirstFunctions;

public static class CatInfoByHttpTrigger
{
    private static readonly HttpClient client = new HttpClient();
    
    [FunctionName("CatInfoByHttpTrigger")]
    public static async Task RunAsync(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req, ILogger log)
    {
        log.LogInformation("C# HTTP trigger function processed a request.");
        var response = await client.GetFromJsonAsync<CatInfo>("https://catfact.ninja/fact");
        log.LogInformation($"Fact: {response?.Fact}");
    }
}