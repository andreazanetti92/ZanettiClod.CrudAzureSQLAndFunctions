using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using ZanettiClod.AzureFunctionsTimerTrigger;
using ZanettiClod.AzureFunctionsTimerTrigger.Data.Interfaces;
using ZanettiClod.AzureFunctionsTimerTrigger.Data.Repository;

[assembly: FunctionsStartup(typeof(Startup))]

namespace ZanettiClod.AzureFunctionsTimerTrigger
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<ILoggerRepository, LoggerRepository>();
        }
    }
}
