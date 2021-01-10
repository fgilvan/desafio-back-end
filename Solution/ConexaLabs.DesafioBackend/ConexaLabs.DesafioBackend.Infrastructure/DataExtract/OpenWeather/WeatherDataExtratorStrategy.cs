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
        private const string parametersByCoordinatesCity = "lat={0}&lat={1}&appid={2}";

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
            var parameters = string.Format(CultureInfo.InvariantCulture, parametersByNameCity, nameCity, "553e0d0373572b1b63f7d91bd69fbb7e");
            var relativeUrl = "data/2.5/weather";

            var obj = GetData(relativeUrl, parameters);

            return obj;
        }

        public OpenWeatherResponse GetCityWeatherByCoordinates(double lat, double lon)
        {
            var parameters = string.Format(CultureInfo.InvariantCulture, parametersByCoordinatesCity, lat, lon, "553e0d0373572b1b63f7d91bd69fbb7e");
            var relativeUrl = "data/2.5/weather";

            var obj = GetData(parameters, relativeUrl);

            return obj;
        }
    }
}
