using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransGr8_DD_Test.Services
{
    internal class LoggerService
    {
        public LoggerService()
        {
            //Configure the Logger
            Log.Logger = new LoggerConfiguration().WriteTo.File("Logs.log").CreateLogger();
        }
    }
}
