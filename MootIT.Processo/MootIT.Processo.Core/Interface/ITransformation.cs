using MootIT.Processo.Repositorio.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MootIT.Processo.Core.Interface
{
    public interface ITransformation<T>
    {
        IColletionRepositorio Transformar(IEnumerable<T> core);

        IColletionRepositorio Transformar(T core);

    }
}
