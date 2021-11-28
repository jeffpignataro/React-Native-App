using api.Models;

namespace api.Interfaces
{
    public interface IWeatherForecast
    {
        WeatherForecast Get();
        void Create(WeatherForecast weatherForecast);
    }    
}