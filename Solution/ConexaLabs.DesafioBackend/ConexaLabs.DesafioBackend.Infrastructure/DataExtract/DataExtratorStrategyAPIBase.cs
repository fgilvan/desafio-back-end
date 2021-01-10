using ConexaLabs.DesafioBackend.Core.DataExtract.Obj;
using ConexaLabs.DesafioBackend.Infrastructure.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Text;

namespace ConexaLabs.DesafioBackend.Infrastructure.DataExtract
{
    public abstract class DataExtratorStrategyAPIBase<TResp>
    {
        protected readonly ReadOnlyCollection<int> timeListInMilliseconds = new ReadOnlyCollection<int>(new[] { 5000, 10000, 15000, 20000 });

        protected abstract string Url { get; }

        protected abstract Token Token { get; }

        /// <summary>
        /// Envia a requisição ao serviço externo.
        /// </summary>
        /// <param name="relativeUrl">URL relativa.</param>
        /// <param name="parameters">Parâmetros GET.</param>
        /// <returns></returns>
        public TResp GetData(string relativeUrl, string parameters)
        {
            HttpResponseMessage requestReturn;
            var url = string.Format(CultureInfo.InvariantCulture, "{0}/{1}", Url, relativeUrl);

            ////Controle de tentativa caso ocorra uma instabilidade na rede.
            ActionRepeat.TryRun(() => APIUtil.SendGetRequest(url, Token, parameters), < T, out requestReturn);

            ////Converte o resultado da requisicao para objeto.
            return APIUtil.ConvertHttpResponseMessageToObject<TResp>(requestReturn);
        }
    }
}
