using ConexaLabs.DesafioBackend.Application.Converters;
using ConexaLabs.DesafioBackend.Application.Interfaces;
using ConexaLabs.DesafioBackend.Application.ViewModel;
using ConexaLabs.DesafioBackend.Core.DataExtract.Interfaces;
using ConexaLabs.DesafioBackend.Core.DataExtract.Obj.Spotify;
using ConexaLabs.DesafioBackend.Core.Enum;
using ConexaLabs.DesafioBackend.Core.Validations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConexaLabs.DesafioBackend.Application.Services
{
    /// <summary>
    /// Serviço de sugestões de playlist.
    /// </summary>
    public class ServicePlaylistSuggestion : ServiceBase<MusicViewModel, SpotifyTrackItem>, IServicePlaylistSuggestion
    {
        private IServiceWeather _serviceWeather;
        private ISpotifyTrackDataExtratorStrategy _spotifyTrackExtratorStrategy;

        public ServicePlaylistSuggestion(IServiceWeather serviceWeather, ISpotifyTrackDataExtratorStrategy spotifyDataExtratorStrategy)
        {
            _serviceWeather = serviceWeather;
            _spotifyTrackExtratorStrategy = spotifyDataExtratorStrategy;
        }

        /// <summary>
        /// Obtém uma playlist com base no nome da cidade informada no parâmetro.
        /// </summary>
        /// <param name="cityName">O nome da cidade.</param>
        /// <returns>A playlist.</returns>
        public IList<MusicViewModel> GetPlaylistByNameCity(string cityName)
        {
            var city = _serviceWeather.GetCityWeatherByNameCity(cityName);

            return GetPlaylistByTemperature(city.Temperature);
        }

        /// <summary>
        /// Obtém uma playlist com base na coordenada geográfica da cidade informada no parâmetro.
        /// </summary>
        /// <param name="lat">Latitude da cidade.</param>
        /// <param name="lon">Longitude da cidade.</param>
        /// <returns>A playlist.</returns>
        public IList<MusicViewModel> GetPlaylistByCoordinatesCity(double lat, double lon)
        {
            var city = _serviceWeather.GetCityWeatherByCoordinates(lat, lon);

            return GetPlaylistByTemperature(city.Temperature);
        }

        /// <summary>
        /// Obtém uma playlist com base na temperatura informada no parâmetro.
        /// </summary>
        /// <param name="temperature">A temperatura.</param>
        /// <returns>A playlist.</returns>
        public IList<MusicViewModel> GetPlaylistByTemperature(double temperature)
        {
            var playListObj = _spotifyTrackExtratorStrategy.GetTrackByGenre(GetGenreByTemperature(temperature));

            return Converter().Converter(playListObj);
        }

        protected override ConverterBase<MusicViewModel, SpotifyTrackItem> Converter()
        {
            return new PlaylistSuggestionConverter();
        }

        protected override AbstractValidator<SpotifyTrackItem> Validator()
        {
            return new SpotifyValidation();
        }

        private EnumSpotifyGenres GetGenreByTemperature(double temperature)
        {
            EnumSpotifyGenres genre;
            var temperatureInCelsius = temperature - 273.15;

            if (temperatureInCelsius >= 30)
                genre = EnumSpotifyGenres.PARTY;
            else if (temperatureInCelsius >= 15 && temperatureInCelsius < 30)
                genre = EnumSpotifyGenres.POP;
            else if (temperatureInCelsius >= 10 && temperatureInCelsius < 15)
                genre = EnumSpotifyGenres.ROCK;
            else
                genre = EnumSpotifyGenres.CLASSICAL;

            return genre;
        }
    }
}
