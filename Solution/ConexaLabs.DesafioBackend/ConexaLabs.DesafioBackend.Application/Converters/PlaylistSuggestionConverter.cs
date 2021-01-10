using ConexaLabs.DesafioBackend.Application.Services;
using ConexaLabs.DesafioBackend.Application.ViewModel;
using ConexaLabs.DesafioBackend.Core.DataExtract.Obj.OpenWeather;
using ConexaLabs.DesafioBackend.Core.DataExtract.Obj.Spotify;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConexaLabs.DesafioBackend.Application.Converters
{
    public class PlaylistSuggestionConverter : ConverterBase<MusicViewModel, SpotifyTrackItem>
    {
        public override MusicViewModel Converter(SpotifyTrackItem item)
        {
            return new MusicViewModel
            {
                Title = item.Track.Album.Name
            };
        }
    }
}
