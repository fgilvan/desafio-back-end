using Newtonsoft.Json;

namespace ConexaLabs.DesafioBackend.Core.DataExtract.Obj.Spotify
{
    public class SpotifyTrack
    {
        [JsonProperty("album")]
        public SpotifyTrackAlbum Album;
    }
}