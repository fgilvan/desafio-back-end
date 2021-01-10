using ConexaLabs.DesafioBackend.Core.DataExtract.Obj.OpenWeather;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConexaLabs.DesafioBackend.Core.Validations
{
    public class OpenWeatherCityValidation: AbstractValidator<OpenWeatherResponse>
    {
        private const string MSG_CITY_NOT_FOUND = "Cidade não encontrada";
        private const string MSG_EXTERNAL_SERVER_NOT_FOUND = "Serviço OpenWeather indisponível";
        private const string MSG_EXTERNAL_SERVER_NOT_AUTHORIZED = "IdApp OpenWeather não autorizado";
        public OpenWeatherCityValidation SignRulesResponse()
        {
            
            RuleFor(x => x)
                .NotNull()
                .WithMessage(MSG_EXTERNAL_SERVER_NOT_FOUND);

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(MSG_CITY_NOT_FOUND);

            RuleFor(x => x.Name)
                .NotEmpty()
                .When(x => x.Code == "401")
                .WithMessage(MSG_EXTERNAL_SERVER_NOT_AUTHORIZED);

            return this;
        }
    }
}
