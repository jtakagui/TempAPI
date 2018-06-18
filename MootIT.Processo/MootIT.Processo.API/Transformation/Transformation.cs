using MootIT.Processo.API.Interface;
using MootIT.Processo.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MootIT.Processo.API.Transformation
{
    public abstract class Transformation<T> : Interface.ITransformation<T>
    {
        public virtual IEnumerable<IDTO> Transformar(IEnumerable<T> core)
        {
            var listaRetorno = new List<IDTO>();

            core.ToList().ForEach(item => listaRetorno.Add(Transformar(item)));

            return listaRetorno;
        }

        public virtual IEnumerable<T> Transformar(IEnumerable<IDTO> contrato)
        {
            var listaRetorno = new List<T>();

            contrato.ToList().ForEach(item => listaRetorno.Add(Transformar(item)));

            return listaRetorno;
        }


        public abstract IDTO Transformar(T contrato);

        public abstract T Transformar(IDTO core);
    }
}
