using ConexaLabs.DesafioBackend.Application.Converters;
using ConexaLabs.DesafioBackend.Core.DataExtract.Obj.OpenWeather;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConexaLabs.DesafioBackend.Application.Services
{
    /// <summary>
    /// Serviço para implementação de serviços CRUD padrão (Não é o caso).
    /// </summary>
    /// <typeparam name="TViewModel">O tipo do ViewModel do serviço.</typeparam>
    /// <typeparam name="TObj">O tipo do objeto do serviço.</typeparam>
    public abstract class ServiceBase<TViewModel, TObj>
        where TViewModel : class
        where TObj : class
    {

        /// <summary>
        /// Exemplo de serviço padrão.
        /// </summary>
        ////public void Create(TViewModel viewModel)
        ////{
        ////    var obj = Converter().Converter(viewModel);

        ////    var validator = Validator().SignRulesResponse(obj);
        ////    validator.ValidateAndThrow(cityWeather);

        ////    Repository().Create(obj);
        ////}

        protected abstract ConverterBase<TViewModel, TObj> Converter();

        protected abstract AbstractValidator<TObj> Validator();
    }
}
