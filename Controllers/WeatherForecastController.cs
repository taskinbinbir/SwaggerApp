using Microsoft.AspNetCore.Mvc;
using SwaggerApp.Models;

namespace SwaggerApp.Controllers;

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
    

    /// <summary>
    /// Return Whole Weather Forecasts
    /// </summary>
    /// <remarks>
    ///  This api just get to whole **Weather Forecasts**
    /// </remarks>
    /// <response code="200">Get Weather Forecast</response> 
    /// <response code="400">Bad Request For Weather Forecast</response> 
    [HttpGet(Name = "GetWeatherForecast")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WeatherForecast[]))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestModel))]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }


    


}
