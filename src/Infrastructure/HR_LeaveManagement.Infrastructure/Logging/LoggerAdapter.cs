using HR_LeaveManagement.Application.Contracts.Logging;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace HR_LeaveManagement.Infrastructure.Logging {
    public class LoggerAdapter<T> : IAppLogger<T> {

        private readonly ILogger<T> _logger;
        public LoggerAdapter(ILoggerFactory loggerFactory) {

            _logger = loggerFactory.CreateLogger<T>();

        }
        public void LogInformation(string message, params object[] args) {

            throw new NotImplementedException();

        }

        public void LogWarning(string message, params object[] args) {
            throw new NotImplementedException();
        }
    }
}
