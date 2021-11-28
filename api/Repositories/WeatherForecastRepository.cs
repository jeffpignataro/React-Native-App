using api.Interfaces;
using api.Models;
using LiteDB;

namespace api.Repositories
{
    public class WeatherForecastRepository : IWeatherForecast
    {
        public WeatherForecast Get(){
            using (var db = new LiteDatabase(@"db/Weather.db"))
            {
                 var weatherForecasts = db.GetCollection<WeatherForecast>("weatherForecasts");

                 return weatherForecasts.FindById(0);
            }
        }

        public void Create(WeatherForecast weatherForecast)
        {
            using (var db = new LiteDatabase(@"db/Weather.db"))
            {
                 var weatherForecasts = db.GetCollection<WeatherForecast>("weatherForecasts");

                 weatherForecasts.Insert(weatherForecast);
            }
        }
    }
}