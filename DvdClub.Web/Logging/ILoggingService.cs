using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ILogger = Serilog.ILogger;

namespace DvdClub.Web.Logging {
    public interface ILoggingService {
        ILogger Writer { get; }
    }
}