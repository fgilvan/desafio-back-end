using ConexaLabs.DesafioBackend.Application.Interfaces;
using ConexaLabs.DesafioBackend.Application.Services;
using ConexaLabs.DesafioBackend.Core.DataExtract.Interfaces;
using ConexaLabs.DesafioBackend.Core.DataExtract.Obj.OpenWeather;
using FluentValidation;
using Moq;
using NUnit.Framework;

namespace ConexaLabs.DesafioBackend.Test.ServicesTest
{
    public class TestServicePlaylistSuggestion
    {
        private const string CITY_NAME = "Goiânia";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_CityNotFound()
        {
            var cityWeatherViewModel = new OpenWeatherResponse
            {
                Code = "404"
            };

            var servico = MockService(cityWeatherViewModel);

            Assert.Throws<ValidationException>(() => servico.GetPlaylistByNameCity(CITY_NAME));
        }

        [Test]
        public void Test_CityAppIdNotFound()
        {
            var cityWeatherViewModel = new OpenWeatherResponse
            {
                Code = "401"
            };

            var servico = MockService(cityWeatherViewModel);

            Assert.Throws<ValidationException>(() => servico.GetPlaylistByNameCity(CITY_NAME));
        }

        [Test]
        public void Test_CityOk()
        {
            var cityWeatherViewModel = new OpenWeatherResponse
            {
                Code = "200",
                Name = CITY_NAME,
                Coordinates = new Coordinates(),
                Main = new Weather()
            };

            var servico = MockService(cityWeatherViewModel);

            Assert.DoesNotThrow(() => servico.GetPlaylistByNameCity(CITY_NAME));
            Assert.NotNull(servico.GetPlaylistByNameCity(CITY_NAME));
        }

        public IServicePlaylistSuggestion MockService(OpenWeatherResponse openWeatherResponse)
        {
            var spotifyDataExtratorStrategy = new Mock<ISpotifyTrackDataExtratorStrategy>();
            var weatherDataExtratorStrategyMock = new Mock<IWeatherDataExtratorStrategy>();
            weatherDataExtratorStrategyMock.Setup(m => m.GetCityWeatherByNameCity(CITY_NAME)).Returns(openWeatherResponse);

            return new ServicePlaylistSuggestion(new ServiceWeather(weatherDataExtratorStrategyMock.Object), spotifyDataExtratorStrategy.Object);
        }
    }
}