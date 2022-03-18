using ReportPortal.Serilog;
using Serilog;
using System;

namespace QAAutomationLab.CoreLayer.Logging
{
    public class ReportPortalLogger
    {
        private static readonly Lazy<ReportPortalLogger> _instance = new(new ReportPortalLogger());

        public ILogger Logger { get; private set; }

        private ReportPortalLogger()
        {
            Logger = new LoggerConfiguration().WriteTo.ReportPortal().CreateLogger();
        }

        public static ReportPortalLogger GetInstance()
        {
            return _instance.Value;
        }
    }
}
