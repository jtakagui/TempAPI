using MootIT.Processo.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MootIT.Processo.Core.Builder
{
    public class LocalizacaoBuilder {
        private Localizacao localizacao;

        public LocalizacaoBuilder() {
            localizacao = new Localizacao();
        }
        public LocalizacaoBuilder Novo(string endereco) {
            localizacao.Endereco = endereco;
            return this;
        }

        public Localizacao Criar() {
            return localizacao;
        }
    }
}
