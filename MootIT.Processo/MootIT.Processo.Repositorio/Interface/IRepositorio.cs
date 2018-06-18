using MootIT.Processo.Repositorio.Collection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MootIT.Processo.Repositorio.Interface
{
    public interface IRepositorio<T> {
        void Incluir(T calculoHistoricoLog);
    }
}
