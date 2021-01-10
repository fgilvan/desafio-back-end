using ConexaLabs.DesafioBackend.Core.DataExtract.Obj;
using ConexaLabs.DesafioBackend.Core.DataExtract.Obj.OpenWeather;
using ConexaLabs.DesafioBackend.Core.DataExtract.Obj.Spotify;
using ConexaLabs.DesafioBackend.Core.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConexaLabs.DesafioBackend.Core.DataExtract.Interfaces
{
    public interface ISpotifyPlaylistDataExtratorStrategy
    {
        SpotifyPlaylistResponse GetPlaylistByGenre(EnumSpotifyGenres genre);
    }
}
