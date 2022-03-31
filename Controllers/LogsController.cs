using BookStore.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private LogsService _logsService;
        private readonly ILogger<PublishersController> _logger;

        public LogsController(LogsService logsService, ILogger<PublishersController> logger)
        {
            _logsService = logsService;
            _logger = logger;   
        }

        [HttpGet("get-all-logs")]
        public IActionResult GetAllLogs()
        {
            try
            {
                _logger.LogInformation("this is a test log in GetAllLogs() --> Logs controller.");
                var logs = _logsService.GetAllLogs();
                return Ok(logs);
            }
            catch
            {
                return BadRequest("Sorry, we could not load the logs.");
            }
        }
    }
}
