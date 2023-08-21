//using Serilog;
//using Serilog.Events;

//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Linq;
//using System.Web;

//namespace DvdClub.Web.Logging {
//    public class LoggingService : ILoggingService {
//        public ILogger Writer => Log.Logger;

//        public LoggingService() {
//            Log.Logger = new LoggerConfiguration()

//            .MinimumLevel.Debug()
//            .WriteTo.Console()

//            .WriteTo.File(
//                path: AppDomain.CurrentDomain.BaseDirectory + "Log/logs.txt",
//                rollingInterval: RollingInterval.Day,
//                shared: true,
//                retainedFileCountLimit: 100,
//                outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}"
//            )
//            .WriteTo.File(
//                formatter: new CompactJsonFormatter(),
//                path: AppDomain.CurrentDomain.BaseDirectory + "Log/logs.json",
//                rollingInterval: RollingInterval.Day,
//                shared: true,
//                retainedFileCountLimit: 100
//            )
//            .WriteTo.ApplicationInsights(
//                TelemetryConfiguration.Active,
//                TelemetryConverter.Events,
//                LogEventLevel.Verbose
//            )
//            .WriteTo.ApplicationInsights(
//                TelemetryConfiguration.Active,
//                TelemetryConverter.Traces,
//                LogEventLevel.Verbose
//             )
//            /*.WriteTo.MicrosoftTeams(
//                ConfigurationManager.AppSettings["Serilog:MicrosoftTeams.webHookUri.Alerts"],
//                title: "eCoupon Alerts Sink",
//                restrictedToMinimumLevel: LogEventLevel.Error
//            )
//            .WriteTo.MicrosoftTeams(
//                ConfigurationManager.AppSettings["Serilog:MicrosoftTeams.webHookUri.Information"],
//                title: "eCoupon Information Sink",
//                restrictedToMinimumLevel: LogEventLevel.Verbose
//            )*/
//            .CreateLogger();
//        }
//    }
//}