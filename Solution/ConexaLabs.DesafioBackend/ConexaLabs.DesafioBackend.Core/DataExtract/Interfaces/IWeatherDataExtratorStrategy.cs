using ConexaLabs.DesafioBackend.Core.DataExtract.Obj;
using ConexaLabs.DesafioBackend.Core.DataExtract.Obj.OpenWeather;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConexaLabs.DesafioBackend.Core.DataExtract.Interfaces
{
    public interface IWeatherDataExtratorStrategy
    {
        OpenWeatherResponse GetCityWeatherByNameCity(string nameCity);

        OpenWeatherResponse GetCityWeatherByCoordinates(double lat, double lon);
    }
}
