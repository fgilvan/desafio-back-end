using Newtonsoft.Json;

namespace ConexaLabs.DesafioBackend.Core.DataExtract.Obj.Spotify
{
    public class SpotifyTrackItem
    {
        [JsonProperty("track")]
        public SpotifyTrack Track;
    }
}