using ConexaLabs.DesafioBackend.Application.Services;
using ConexaLabs.DesafioBackend.Application.ViewModel;
using ConexaLabs.DesafioBackend.Core.DataExtract.Obj.OpenWeather;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConexaLabs.DesafioBackend.Application.Converters
{
    public class CityWeatherConverter: ConverterBase<CityWeatherViewModel, OpenWeatherResponse>
    {
        public override CityWeatherViewModel Converter(OpenWeatherResponse item)
        {
            return new CityWeatherViewModel
            {
                Lat = item.Coordinates.Lat,
                Lon = item.Coordinates.Lon,
                Name = item.Name,
                Temperature = item.Main.Temp
            };
        }
    }
}
