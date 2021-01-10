using ConexaLabs.DesafioBackend.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConexaLabs.DesafioBackend.Application.Interfaces
{
    /// <summary>
    /// Interface de serviço de consulta de dados da OpenWeather.
    /// </summary>
    public interface IServiceWeather
    {
        /// <summary>
        /// Obtém o clima de uma cidade com base nos parâmetros.
        /// </summary>
        /// <param name="cityName">O nome da cidade.</param>
        /// <returns>O objeto MusicViewModel.</returns>
        CityWeatherViewModel GetCityWeatherByNameCity(string cityName);

        /// <summary>
        /// Obtém o clima de uma cidade com base nos parâmetros.
        /// </summary>
        /// <param name="lat">Latitude da cidade.</param>
        /// <param name="lon">Longitude da cidade.</param>
        /// <returns>O objeto MusicViewModel.</returns>
        CityWeatherViewModel GetCityWeatherByCoordinates(double lat, double lon);
    }
}
