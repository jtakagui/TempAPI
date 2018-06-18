using MootIT.Processo.Core.Interface;
using MootIT.Processo.Repositorio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MootIT.Processo.Core.Transforma
{
    public abstract class Transformation<T> : ITransformation<T>
    {
        public abstract IColletionRepositorio Transformar(IEnumerable<T> core);

        public abstract IColletionRepositorio Transformar(T core);

    }
}
