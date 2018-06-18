using MootIT.Processo.API.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MootIT.Processo.API.Builder
{
    public class LocalizacaoBuilder
    {
        private Localizacao localizacao;

        public LocalizacaoBuilder()
        {
            localizacao = new Localizacao();
        }
        public LocalizacaoBuilder Novo(string endereco)
        {
            localizacao.Endereco = endereco;
            return this;
        }

        public Localizacao Criar()
        {
            return localizacao;
        }
    }
}
