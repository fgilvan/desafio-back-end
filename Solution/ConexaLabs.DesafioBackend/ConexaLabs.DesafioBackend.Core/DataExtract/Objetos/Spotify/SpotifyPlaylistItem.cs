using Newtonsoft.Json;

namespace ConexaLabs.DesafioBackend.Core.DataExtract.Obj.Spotify
{
    public class SpotifyPlaylistItem
    {
        [JsonProperty("id")]
        public string IdPlaylist;
    }
}