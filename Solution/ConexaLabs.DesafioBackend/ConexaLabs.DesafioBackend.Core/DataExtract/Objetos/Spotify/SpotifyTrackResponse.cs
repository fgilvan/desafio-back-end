using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConexaLabs.DesafioBackend.Core.DataExtract.Obj.Spotify
{
    public class SpotifyTrackResponse
    {
        [JsonProperty("href")]
        public string Href;

        [JsonProperty("items")]
        public IList<SpotifyTrackItem> Tracks;
    }
}
