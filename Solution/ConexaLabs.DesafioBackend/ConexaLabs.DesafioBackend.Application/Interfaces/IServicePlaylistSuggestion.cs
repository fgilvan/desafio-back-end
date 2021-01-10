using ConexaLabs.DesafioBackend.Application.ViewModel;
using ConexaLabs.DesafioBackend.Core.DataExtract.Obj.OpenWeather;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConexaLabs.DesafioBackend.Application.Interfaces
{
    /// <summary>
    /// Interface de serviço de sugestões de playlist.
    /// </summary>
    public interface IServicePlaylistSuggestion
    {
        /// <summary>
        /// Obtém uma playlist com base no nome da cidade informada no parâmetro.
        /// </summary>
        /// <param name="cityName">O nome da cidade.</param>
        /// <returns>A playlist.</returns>
        IList<MusicViewModel> GetPlaylistByNameCity(string cityName);

        /// <summary>
        /// Obtém uma playlist com base na coordenada geográfica da cidade informada no parâmetro.
        /// </summary>
        /// <param name="lat">Latitude da cidade.</param>
        /// <param name="lon">Longitude da cidade.</param>
        /// <returns>A playlist.</returns>
        IList<MusicViewModel> GetPlaylistByCoordinatesCity(double lat, double lon);

        /// <summary>
        /// Obtém uma playlist com base na temperatura informada no parâmetro.
        /// </summary>
        /// <param name="lat">Latitude da cidade.</param>
        /// <param name="lon">Longitude da cidade.</param>
        /// <returns>A playlist.</returns>
        IList<MusicViewModel> GetPlaylistByTemperature(double temperature);
    }
}
