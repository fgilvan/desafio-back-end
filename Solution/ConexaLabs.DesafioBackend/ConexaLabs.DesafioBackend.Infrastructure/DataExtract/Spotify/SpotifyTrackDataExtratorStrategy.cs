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
using System.Linq;

namespace ConexaLabs.DesafioBackend.Infrastructure.DataExtract.Spotify
{
    public class SpotifyTrackDataExtratorStrategy : SpotifyDataExtratorStrategyBase<SpotifyTrackResponse>, ISpotifyTrackDataExtratorStrategy
    {
        private ISpotifyPlaylistDataExtratorStrategy _spotifyPlaylistDataExtratorStrategy;

        public SpotifyTrackDataExtratorStrategy(ISpotifyPlaylistDataExtratorStrategy spotifyPlaylistDataExtratorStrategy)
        {
            _spotifyPlaylistDataExtratorStrategy = spotifyPlaylistDataExtratorStrategy;
        }

        public IList<SpotifyTrackItem> GetTrackByGenre(EnumSpotifyGenres genre)
        {
            var playlistResponse = _spotifyPlaylistDataExtratorStrategy.GetPlaylistByGenre(genre)?.Playlist.PlaylistItens.FirstOrDefault();

            if (playlistResponse == null)
                return null;

            var relativeUrl = string.Format(CultureInfo.InvariantCulture, "playlists/{0}/tracks", playlistResponse.IdPlaylist);

            var obj = GetData(relativeUrl, string.Empty);

            return obj?.Tracks;
        }
    }
}
