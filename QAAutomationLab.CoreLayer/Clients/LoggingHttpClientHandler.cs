using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using QAAutomationLab.CoreLayer.Logging;

namespace QAAutomationLab.CoreLayer.Clients
{
    internal class LoggingHttpClientHandler : DelegatingHandler
    {
        private ReportPortalLogger _logger = ReportPortalLogger.GetInstance();

        internal LoggingHttpClientHandler()
            : base(new HttpClientHandler()) { }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = base.SendAsync(request, cancellationToken);
            _logger.Logger.Information($"{request.Method} request started execution with uri:" +
                $"{request.RequestUri}. " +
                $"Response id: {response.Id}");

            await response;
            _logger.Logger.Information($"Response {response.Id} result: {response.Result}");
            _logger.Logger.Information($"Response {response.Id} status: {response.Status}");

            return await response;
        }
    }
}
