using Newtonsoft.Json;
using System.Collections.Generic;

namespace ConexaLabs.DesafioBackend.Core.DataExtract.Obj.Spotify
{
    public class SpotifyPlaylist
    {
        [JsonProperty("items")]
        public IList<SpotifyPlaylistItem> PlaylistItens;
    }
}