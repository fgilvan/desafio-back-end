using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConexaLabs.DesafioBackend.Infrastructure.Util
{
    public static class ActionRepeat
    {
        /// <summary>
        /// Tenta executar uma função X vezes, com intervalo crescente em cada tentativa.
        /// Utilize o parâmetro listaTempoEsperaEmMilisegundos para definir os intervalos de tempo das tentativas.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="funcion"></param>
        /// <param name="timeListInMilliseconds"></param>
        /// <param name="outputFuncion"></param>
        /// <returns></returns>
        public static void TryRun<T>(Func<T> funcion, IList<int> timeListInMilliseconds, out T outputFuncion)
        {
            outputFuncion = default(T);
            var repetitionsNumber = timeListInMilliseconds.Count;
            var repetition = 0;

            if (funcion == null)
            {
                throw new ArgumentNullException("funcao");
            }

            do
            {
                try
                {
                    outputFuncion = funcion();

                    return;
                }
                catch (Exception ex)
                {
                    if (repetition >= repetitionsNumber)
                    {
                        throw;
                    }
                }
                finally
                {
                    repetition++;
                }

                if (repetitionsNumber > 0 && repetition <= repetitionsNumber)
                {
                    var tempoEsperaEmMilisegundos = timeListInMilliseconds[repetition - 1];

                    Thread.Sleep(tempoEsperaEmMilisegundos);
                }
            }
            while (repetition <= repetitionsNumber);
        }
    }
}
