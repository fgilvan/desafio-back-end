using ConexaLabs.DesafioBackend.Application.Converters;
using ConexaLabs.DesafioBackend.Application.Interfaces;
using ConexaLabs.DesafioBackend.Application.ViewModel;
using ConexaLabs.DesafioBackend.Core.DataExtract.Interfaces;
using ConexaLabs.DesafioBackend.Core.DataExtract.Obj.OpenWeather;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConexaLabs.DesafioBackend.Application.Services
{
    /// <summary>
    /// Serviço de consulta de dados da OpenWeather.
    /// </summary>
    public class ServiceWeather : ServiceBase<CityWeatherViewModel, OpenWeatherResponse>, IServiceWeather
    {
        private IWeatherDataExtratorStrategy _weatherDataExtratorStrategy;

        public ServiceWeather(IWeatherDataExtratorStrategy weatherDataExtratorStrategy)
        {
            _weatherDataExtratorStrategy = weatherDataExtratorStrategy;
        }

        /// <summary>
        /// Obtém o clima de uma cidade com base nos parâmetros.
        /// </summary>
        /// <param name="cityName">O nome da cidade.</param>
        /// <returns>O objeto MusicViewModel.</returns>
        public CityWeatherViewModel GetCityWeatherByNameCity(string cityName)
        {
            var cityWeather = _weatherDataExtratorStrategy.GetCityWeatherByNameCity(cityName);

            return Converter().Converter(cityWeather);
        }

        /// <summary>
        /// Obtém o clima de uma cidade com base nos parâmetros.
        /// </summary>
        /// <param name="lat">Latitude da cidade.</param>
        /// <param name="lon">Longitude da cidade.</param>
        /// <returns>O objeto MusicViewModel.</returns>
        public CityWeatherViewModel GetCityWeatherByCoordinates(double lat, double lon)
        {
            var cityWeather = _weatherDataExtratorStrategy.GetCityWeatherByCoordinates(lat, lon);

            return Converter().Converter(cityWeather);
        }

        protected override ConverterBase<CityWeatherViewModel, OpenWeatherResponse> Converter()
        {
            return new CityWeatherConverter();
        }
    }
}
