using System;
using System.Collections.Generic;
using System.Text;

namespace MyBackEnd.Core.CrossCuttingConcerns.Logging.Log4Net
{
    public class LogDetailWithException:LogDetail
    {
        public string ExceptionMessage { get; set; }
    }
}
