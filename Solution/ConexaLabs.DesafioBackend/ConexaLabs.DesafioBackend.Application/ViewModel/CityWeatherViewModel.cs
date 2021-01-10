using System;
using System.Collections.Generic;
using System.Text;

namespace ConexaLabs.DesafioBackend.Application.ViewModel
{
    public class CityWeatherViewModel
    {
        /// <summary>
        /// O nome da cidade.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Latitude da cidade.
        /// </summary>
        public Double Lat { get; set; }

        /// <summary>
        /// Longitude da cidade.
        /// </summary>
        public Double Lon { get; set; }

        /// <summary>
        /// Temperatura atual da cidade
        /// </summary>
        public Double Temperature { get; set; }

    }
}
