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
        public static async Task Run([TimerTrigger("%TimerScheduler%")] TimerInfo myTimer, ILogger log)
        {
            // 時間外起動はそのまま終了
            if (myTimer.IsPastDue) return;

            var message = $"Message: {GetEnvironmentVariable("EnvironmentVariableMessage")}";
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
        /// 環境変数値を取得する
        /// 参考:https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-dotnet-class-library#environment-variables
        /// </summary>
        /// <param name="name">環境変数名</param>
        /// <returns>環境変数値</returns>
        public static string GetEnvironmentVariable(string name)
        {
            return Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Process);
        }
    }
}
