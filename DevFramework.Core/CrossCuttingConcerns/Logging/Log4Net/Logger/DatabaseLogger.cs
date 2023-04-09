using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Logger
{
    public class DatabaseLogger : LoggerService
    {
        public DatabaseLogger(ILog log) : base(LogManager.GetLogger("DatabaseLogger"))
        {
        }
    }
}
