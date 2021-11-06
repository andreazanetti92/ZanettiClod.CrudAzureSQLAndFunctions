using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using ZanettiClod.AzureFunctionsTimerTrigger.Data.Interfaces;

namespace ZanettiClod.AzureFunctionsTimerTrigger
{
    public class LoggerCountProducts
    {
        private readonly ILoggerRepository _loggerRepository;

        public LoggerCountProducts(ILoggerRepository loggerRepository)
        {
            _loggerRepository = loggerRepository;
        }

        [FunctionName("LoggerCountProducts")]
        public async Task Run([TimerTrigger("0 */2 * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            await _loggerRepository.GetProductCountAndWriteAsync();
        }
    }
}
