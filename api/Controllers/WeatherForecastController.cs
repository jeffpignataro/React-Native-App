using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherForecast repo;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecast repo)
    {
        this._logger = logger;
        this.repo = repo;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    [Route("Get")]
    public IEnumerable<WeatherForecast> Get()
    {
        var repoValue = repo.Get();

        var weatherForecasts = new List<WeatherForecast>() { repoValue };

        return weatherForecasts;
    }

    [HttpGet(Name = "CreateWeatherForecast")]
    [Route("Create")]
    public void Create()
    {
        var weatherForecast = new WeatherForecast
        {
            Date = DateTime.Now,
            TemperatureC = new Random().Next(-20, 55),
            Summary = Summaries[new Random().Next(Summaries.Length)]
        };

        repo.Create(weatherForecast);
    }


}
