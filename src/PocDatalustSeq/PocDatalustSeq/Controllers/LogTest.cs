using Microsoft.AspNetCore.Mvc;

namespace PocDatalustSeq.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogTest : ControllerBase
    {

        private readonly ILogger<LogTest> _logger;

        public LogTest(ILogger<LogTest> logger)
        {
            _logger = logger;
        }

        [HttpPost, Route("log")]
        public void Log(LogLevel logLevel, string logMessage)
        {
            _logger.Log(logLevel, logMessage);
        }

        [HttpPost, Route("scoped-log")]
        public void ScopedLog(LogLevel logLevel, string logMessage, string scope)
        {
            using var _ = _logger.BeginScope(scope);

            _logger.Log(logLevel, logMessage);
        }
    }
}