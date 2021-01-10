using ConexaLabs.DesafioBackend.Core.DataExtract.Interfaces;
using ConexaLabs.DesafioBackend.Core.DataExtract.Obj;
using ConexaLabs.DesafioBackend.Core.DataExtract.Obj.OpenWeather;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ConexaLabs.DesafioBackend.Infrastructure.DataExtract.OpenWeather
{
    public class WeatherDataExtratorStrategy: DataExtratorStrategyAPIBase<OpenWeatherResponse>, IWeatherDataExtratorStrategy
    {
        private const string parametersByNameCity = "q={0}&appid={1}";
        private const string parametersByCoordinatesCity = "lat={0}&lon={1}&appid={2}";

        protected override string Url
        {
            get
            {
                return "http://api.openweathermap.org";
            }
        }

        protected override Token Token
        {
            get
            {
                return null;
            }
        }

        public OpenWeatherResponse GetCityWeatherByNameCity(string nameCity)
        {
            var appId = ApplicationConfig.GetAppSettings("OpenWeather:AppId");

            var parameters = string.Format(CultureInfo.InvariantCulture, parametersByNameCity, nameCity, appId);

            return GetOpenWeather(parameters);
        }

        public OpenWeatherResponse GetCityWeatherByCoordinates(double lat, double lon)
        {
            var appId = ApplicationConfig.GetAppSettings("OpenWeather:AppId");

            var parameters = string.Format(CultureInfo.InvariantCulture, parametersByCoordinatesCity, lat, lon, appId);

            return GetOpenWeather(parameters);
        }

        private OpenWeatherResponse GetOpenWeather(string parameters)
        {
            var relativeUrl = "data/2.5/weather";

            var obj = GetData(relativeUrl, parameters);

            return obj;
        }
    }
}
