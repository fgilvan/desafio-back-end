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
    public class SpotifyPlaylistDataExtratorStrategy : SpotifyDataExtratorStrategyBase<SpotifyPlaylistResponse>, ISpotifyPlaylistDataExtratorStrategy
    {
        private const string parametersByGenrer = "limit=1";

        public SpotifyPlaylistResponse GetPlaylistByGenre(EnumSpotifyGenres genre)
        {
            var relativeUrl = string.Format(CultureInfo.InvariantCulture, "browse/categories/{0}/playlists", genre.ToString().ToLower());

            var obj = GetData(relativeUrl, parametersByGenrer);

            return obj;
        }
    }
}
