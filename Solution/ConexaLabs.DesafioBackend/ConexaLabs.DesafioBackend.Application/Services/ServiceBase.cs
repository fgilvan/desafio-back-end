using ConexaLabs.DesafioBackend.Application.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConexaLabs.DesafioBackend.Application.Services
{
    /// <summary>
    /// Serviço para implementação de serviços CRUD padrão.
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

        ////    Validator().CreateValidate(obj);

        ////    Repository().Create(obj);
        ////}

        protected abstract ConverterBase<TViewModel, TObj> Converter();
    }
}
