using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConexaLabs.DesafioBackend.Core.DataExtract.Obj.OpenWeather
{
    public class OpenWeatherResponse
    {
        [JsonProperty("coord")]
        public Coordinates Coordinates;

        [JsonProperty("main")]
        public Weather Main;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("cod")]
        public string Code;

        [JsonProperty("message")]
        public string Message;
    }
}
