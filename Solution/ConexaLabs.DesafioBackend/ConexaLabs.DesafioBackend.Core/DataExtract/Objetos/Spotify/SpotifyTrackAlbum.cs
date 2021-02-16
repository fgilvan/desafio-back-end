using Newtonsoft.Json;

namespace ConexaLabs.DesafioBackend.Core.DataExtract.Obj.Spotify
{
    public class SpotifyTrackAlbum
    {
        [JsonProperty("name")]
        public string Name;
    }
}