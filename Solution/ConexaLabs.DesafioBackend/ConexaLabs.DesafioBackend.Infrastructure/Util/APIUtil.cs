using ConexaLabs.DesafioBackend.Core.DataExtract.Obj;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace ConexaLabs.DesafioBackend.Infrastructure.Util
{
    public static class APIUtil
    {
        public static HttpResponseMessage SendGetRequest(string url, Token token, string parameter)
        {
            HttpResponseMessage response;

            using (var httpClient = new HttpClient())
            {
                var uri = new Uri(string.Format(CultureInfo.InvariantCulture, "{0}?{1}", url, parameter));

                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                httpClient.Timeout = TimeSpan.FromMinutes(30);

                if (token != null && token.AccessToken != string.Empty)
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token.TokenType, token.AccessToken);

                response = httpClient.GetAsync(uri).Result;

                return response;
            }
        }

        public static Token GetTokenAccess(string url, string credentialClientId, string credentialClientSecret)
        {
            Token token = null;

            if (credentialClientId == null || credentialClientSecret == null)
            {
                return token;
            }

            HttpResponseMessage response;

            using (var httpClient = new HttpClient())
            {
                var credential = string.Format(CultureInfo.InvariantCulture, "{0}:{1}", credentialClientId, credentialClientSecret);
                var credentialBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(credential));

                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", credentialBase64);

                var formContent = new FormUrlEncodedContent(new[]
                                                                {
                                                                    new KeyValuePair<string, string>("grant_type", "client_credentials"),
                                                                    new KeyValuePair<string, string>("Content-Type", "application/x-www-form-urlencoded")
                                                                });

                response = httpClient.PostAsync(url, formContent).Result;
            }

            token = ConvertHttpResponseMessageToObject<Token>(response);

            return token;
        }

        public static T ConvertHttpResponseMessageToObject<T>(HttpResponseMessage response)
        {
            var responseStream = response.Content.ReadAsStreamAsync().Result;
            if (responseStream == null)
            {
                throw new NoNullAllowedException("responseStream");
            }

            var serializer = new JsonSerializer();

            using (var reader = new StreamReader(responseStream, Encoding.UTF8))
            using (var jsonTextReader = new JsonTextReader(reader))
            {
                return serializer.Deserialize<T>(jsonTextReader);
            }
        }
    }
}
