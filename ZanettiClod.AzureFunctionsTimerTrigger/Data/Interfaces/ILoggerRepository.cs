using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ZanettiClod.AzureFunctionsTimerTrigger.Data.Interfaces
{
    public interface ILoggerRepository
    {
        public Task GetProductCountAndWriteAsync();
    }
}
