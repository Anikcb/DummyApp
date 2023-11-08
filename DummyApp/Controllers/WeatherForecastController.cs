using DummyApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DummyApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IOperationTransient _transientOp;
        private readonly IOperationSingleton _singletonOp;
        private readonly IOperationScoped _scopedOp;

        public WeatherForecastController(
        
            IOperationSingleton singletonOp, 
            IOperationScoped scopedOp,
            IOperationTransient transientOp,
            ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _transientOp = transientOp;
            _singletonOp = singletonOp;
            _scopedOp = scopedOp;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get()
        {
            _logger.LogInformation("Hello.....");
            _logger.LogInformation($"Transient: {_transientOp.OperationId}");
            _logger.LogInformation($"Scoped: {_scopedOp.OperationId}");
            _logger.LogInformation($"Singleton: {_singletonOp.OperationId}");
            return Ok();
        }
    }
}