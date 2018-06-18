using MootIT.Processo.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MootIT.Processo.API.Interface
{
    public interface ITransformation<T>
    {
        IEnumerable<IDTO> Transformar(IEnumerable<T> core);

        IEnumerable<T> Transformar(IEnumerable<IDTO> contrato);

        IDTO Transformar(T contrato);

        T Transformar(IDTO core);
    }
}
