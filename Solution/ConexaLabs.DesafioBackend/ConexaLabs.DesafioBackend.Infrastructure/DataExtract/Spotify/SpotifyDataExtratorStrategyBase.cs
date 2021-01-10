using ConexaLabs.DesafioBackend.Core.DataExtract.Interfaces;
using ConexaLabs.DesafioBackend.Core.DataExtract.Obj;
using ConexaLabs.DesafioBackend.Core.DataExtract.Obj.OpenWeather;
using ConexaLabs.DesafioBackend.Core.DataExtract.Obj.Spotify;
using ConexaLabs.DesafioBackend.Core.Enum;
using ConexaLabs.DesafioBackend.Infrastructure.Util;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ConexaLabs.DesafioBackend.Infrastructure.DataExtract.Spotify
{
    /// <summary>
    /// Classe com algumas propriedades em comum da estratégia de extração de dados do Spotify
    /// </summary>
    public class SpotifyDataExtratorStrategyBase<T> : DataExtratorStrategyAPIBase<T>
    {
        private Token _token;
        private DateTime _tokenExpirationDate;
        private string _urlToken = "https://accounts.spotify.com/api/token";

        protected override string Url
        {
            get
            {
                return "https://api.spotify.com/v1";
            }
        }

        protected override Token Token
        {
            get
            {
                ////Verifica se o token não foi inicializado ou se seu tempo de vida expirou.
                if(_token == null || (_token != null && _tokenExpirationDate >= DateTime.Now))
                {
                    var clientId = ApplicationConfig.GetAppSettings("Spotify:ClientId");
                    var clientSecret = ApplicationConfig.GetAppSettings("Spotify:ClientSecret");

                    _token = APIUtil.GetTokenAccess(_urlToken, clientId, clientSecret);
                    _tokenExpirationDate = DateTime.Now.AddSeconds(_token.ExpiresIn);
                }

                return _token;
            }
        }
    }
}
