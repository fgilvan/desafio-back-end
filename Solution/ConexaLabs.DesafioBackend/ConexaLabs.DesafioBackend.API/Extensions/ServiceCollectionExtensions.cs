using ConexaLabs.DesafioBackend.Application.Interfaces;
using ConexaLabs.DesafioBackend.Application.Services;
using ConexaLabs.DesafioBackend.Core.DataExtract.Interfaces;
using ConexaLabs.DesafioBackend.Infrastructure.DataExtract;
using ConexaLabs.DesafioBackend.Infrastructure.DataExtract.OpenWeather;
using ConexaLabs.DesafioBackend.Infrastructure.DataExtract.Spotify;
using Microsoft.Extensions.DependencyInjection;

namespace LiveCleanArchitecture.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IServicePlaylistSuggestion, ServicePlaylistSuggestion>();
            services.AddScoped<IServiceWeather, ServiceWeather>();

            return services;
        }

        public static IServiceCollection AddDataExtract(this IServiceCollection services)
        {
            services.AddScoped<IWeatherDataExtratorStrategy, WeatherDataExtratorStrategy>();
            services.AddScoped<ISpotifyTrackDataExtratorStrategy, SpotifyTrackDataExtratorStrategy>();
            services.AddScoped<ISpotifyPlaylistDataExtratorStrategy, SpotifyPlaylistDataExtratorStrategy>();

            return services;
        }
    }
}
