using MootIT.Processo.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MootIT.Processo.Core.Extension
{
    public static class AmigoExtension
    {
        public static void ValidarDuplicidade(this IEnumerable<Amigo> amigos) {
            var duplicados = amigos.GroupBy(s => s.Localizacao.Endereco).SelectMany(grp => grp.Skip(1));
            if(duplicados.Count() > 0) throw new ArgumentException("Foram encontrados dois amigos em um único endereço");
        }
    }
}
