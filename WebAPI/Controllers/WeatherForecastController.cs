using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly LoggingAPIContext _loggingAPIContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, LoggingAPIContext loggingAPIContext)
        {
            _logger = logger;
            _loggingAPIContext = loggingAPIContext;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            throw new IndexOutOfRangeException();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }


        /// <summary>
        /// API to Log Exceptions in the Database.
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        [HttpPost(nameof(LogExceptions))]
        public async Task<IActionResult> LogExceptions(LogModel log)
        {
            var logs = new Log();
            logs.ExceptionMessage = log.ExceptionMessage;
            logs.Source = log.Source;
            logs.LineNumber = log.LineNumber;
            logs.FilePath = log.FilePath;
            logs.CretedDate = DateTime.UtcNow;
            await _loggingAPIContext.Logs.AddAsync(logs);
            await _loggingAPIContext.SaveChangesAsync();
            return Ok("Details Saved!");
        }
    }
    public class LogModel
    {
        public string Source { get; set; }
        public string FilePath { get; set; }
        public int LineNumber { get; set; }
        public string ExceptionMessage { get; set; }
        public DateTime CreatedDate { get; set; }
    }

}