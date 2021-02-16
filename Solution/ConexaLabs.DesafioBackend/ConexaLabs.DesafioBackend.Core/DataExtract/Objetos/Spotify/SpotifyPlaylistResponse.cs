using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConexaLabs.DesafioBackend.Core.DataExtract.Obj.Spotify
{
    public class SpotifyPlaylistResponse
    {
        [JsonProperty("playlists")]
        public SpotifyPlaylist Playlist;
    }
}
