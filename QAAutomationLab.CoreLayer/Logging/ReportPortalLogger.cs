using System;
using ReportPortal.Serilog;
using Serilog;

namespace QAAutomationLab.CoreLayer.Logging
{
    public class ReportPortalLogger
    {
        private static readonly Lazy<ReportPortalLogger> _instance = new(new ReportPortalLogger());

        private ReportPortalLogger()
        {
            Logger = new LoggerConfiguration().WriteTo.ReportPortal().CreateLogger();
        }

        public ILogger Logger { get; private set; }

        public static ReportPortalLogger GetInstance()
        {
            return _instance.Value;
        }
    }
}
