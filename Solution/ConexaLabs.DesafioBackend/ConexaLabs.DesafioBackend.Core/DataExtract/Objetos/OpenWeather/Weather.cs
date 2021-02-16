
using Newtonsoft.Json;

namespace ConexaLabs.DesafioBackend.Core.DataExtract.Obj.OpenWeather
{
    public class Weather
    {
        [JsonProperty("temp")]
        public double Temp;
    }
}