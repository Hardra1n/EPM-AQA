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

            _ = RegisterResponse(response);

            return await response;
        }

        private async Task RegisterResponse(Task<HttpResponseMessage> response)
        {
            await response;
            _logger.Logger.Information($"Response with id {response.Id} result: {response.Result}");
            switch (response.Status)
            {
                case TaskStatus.RanToCompletion:
                    _logger.Logger.Information($"Response with id {response.Id} completed");
                    break;
                case TaskStatus.Canceled:
                    _logger.Logger.Information($"Response with id {response.Id} cancelled");
                    break;
                case TaskStatus.Faulted:
                    _logger.Logger.Error($"Response with id {response.Id} faulted");
                    break;
                default:
                    _logger.Logger.Error($"Unrecognized response status. Response id {response.Id}");
                    break;
            }
        }
    }
}
