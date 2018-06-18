using MootIT.Processo.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MootIT.Processo.Core.Interface
{
    public interface ILocalizarAmigoMaisProximo<T>
    {
        IEnumerable<T> Executar(IEnumerable<T> amigos);
    }
}
