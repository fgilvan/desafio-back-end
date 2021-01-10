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
                if(_token == null || (_token != null && _tokenExpirationDate >= DateTime.Now))
                {
                    _token = APIUtil.GetTokenAccess("https://accounts.spotify.com/api/token", "7b67aaa9c01f499799560ba1b1542019", "4cb0f867e1f44a8c8fbe256850cf163f");
                    _tokenExpirationDate = DateTime.Now.AddSeconds(_token.ExpiresIn);
                }

                return _token;
            }
        }
    }
}
