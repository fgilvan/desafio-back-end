using System;
using System.Collections.Generic;
using System.Text;


namespace ConexaLabs.DesafioBackend.Application.Converters
{
    public class ConverterBase<TViewModel, TObj> 
        where TViewModel : class
        where TObj : class
    {
        public virtual IList<TObj> Converter(IList<TViewModel> listViewModel)
        {
            var listObj = new List<TObj>();

            if(listViewModel == null)
            {
                return listObj;
            }

            foreach(var item in listViewModel)
            {
                listObj.Add(Converter(item));
            }

            return listObj;
        }

        public virtual IList<TViewModel> Converter(IList<TObj> listObj)
        {
            var listViewModel = new List<TViewModel>();

            if (listViewModel == null)
            {
                return listViewModel;
            }

            foreach (var item in listObj)
            {
                listViewModel.Add(Converter(item));
            }

            return listViewModel;
        }

        public virtual TObj Converter(TViewModel item)
        {
            ////Implementar um conversor genérico
            throw new NotImplementedException();
        }

        public virtual TViewModel Converter(TObj item)
        {
            ////Implementar um conversor genérico
            throw new NotImplementedException();
        }
    }
}