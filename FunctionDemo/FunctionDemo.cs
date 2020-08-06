using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace FunctionDemo
{
    public static class FunctionDemo
    {
        [FunctionName("FunctionDemo")]
        public static async Task Run([TimerTrigger("0 */1 * * * *")] TimerInfo myTimer, ILogger log)
        {
            // 時間外起動はそのまま終了
            if (myTimer.IsPastDue) return;

            var message = $"C# Timer trigger function executed at: {DateTime.Now}";
            log.LogInformation(message);

            var parameters = new Dictionary<string, string>()
            {
                { "message", message}
            };

            var content = new FormUrlEncodedContent(parameters);

            using var client = new HttpClient();

            var response = await client.PostAsync(GetEnvironmentVariable("PostUrl"), content);
            log.LogInformation(response.StatusCode.ToString());

        }
        /// <summary>
        /// 参考:https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-dotnet-class-library#environment-variables
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetEnvironmentVariable(string name)
        {
            return Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Process);
        }
    }
}
