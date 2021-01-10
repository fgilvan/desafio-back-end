using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConexaLabs.DesafioBackend.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;

namespace ConexaLabs.DesafioBackend.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PlaylistSuggestionController : ControllerBase
    {
        public IServicePlaylistSuggestion ServicePlaylistSuggestion;

        public PlaylistSuggestionController(IServicePlaylistSuggestion servicePlaylistSuggestion)
        {
            ServicePlaylistSuggestion = servicePlaylistSuggestion;
        }


        /// <summary>
        /// Obtém uma playlist com base no nome da cidade informada no parâmetro.
        /// A categoria das músicas da playlist será de acordo com a temperatura atual da cidade.
        /// </summary>
        /// <param name="cityName">O nome da cidade.</param>
        /// <returns>A playlist.</returns>
        [HttpGet("[Action]")]
        public IActionResult GetPlaylistByNameCity(string cityName)
        {
            try
            {
                var playlist = ServicePlaylistSuggestion.GetPlaylistByNameCity(cityName);

                return Ok(playlist);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Obtém uma playlist com base na coordenada geográfica da cidade informada no parâmetro.
        /// A categoria das músicas da playlist será de acordo com a temperatura atual da cidade.
        /// </summary>
        /// <param name="lat">Latitude da cidade.</param>
        /// <param name="lon">Longitude da cidade.</param>
        /// <returns>A playlist.</returns>
        [HttpGet("[Action]")]
        public IActionResult GetPlaylistByCoordinatesCity(double lat, double lon)
        {
            try
            {
                var playlist = ServicePlaylistSuggestion.GetPlaylistByCoordinatesCity(lat, lon);

                return Ok(playlist);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
