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
            // ���ԊO�N���͂��̂܂܏I��
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
        /// ���ϐ��l���擾����
        /// �Q�l:https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-dotnet-class-library#environment-variables
        /// </summary>
        /// <param name="name">���ϐ���</param>
        /// <returns>���ϐ��l</returns>
        public static string GetEnvironmentVariable(string name)
        {
            return Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Process);
        }
    }
}
