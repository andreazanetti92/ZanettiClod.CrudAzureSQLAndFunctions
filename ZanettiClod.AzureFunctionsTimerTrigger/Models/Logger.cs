using System;
using System.Collections.Generic;
using System.Text;

namespace ZanettiClod.AzureFunctionsTimerTrigger.Models
{
    public class Logger
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
    }
}
