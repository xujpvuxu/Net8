using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Net8.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public void Get()
    {
        _logger.LogTrace("{RequestId},Trace");
        _logger.LogDebug("{RequestId},Debug");
        _logger.LogInformation("Infomation");
        _logger.LogWarning("Warning");
        _logger.LogError("Error");
        _logger.LogCritical("Critical");
    }

    [HttpGet("t", Name = "abc")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesDefaultResponseType]
    public ActionResult Get1()
    {
        Random rng = new Random();
        if (rng.Next(2) > 0)
        {
            return NoContent();
        }
        else
        {
            return Ok();
        }
    }
}