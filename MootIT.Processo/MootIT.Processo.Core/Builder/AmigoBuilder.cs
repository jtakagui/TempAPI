using MootIT.Processo.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MootIT.Processo.Core.Builder
{
    public class AmigoBuilder
    {
        private Amigo amigo;

        public AmigoBuilder() {
            amigo = new Amigo();
        }

        public AmigoBuilder Novo(string nome) {
            amigo.Nome = nome;
            return this;
        }

        public AmigoBuilder ComLocalizacao(string endereco) {
            var localizacao = new LocalizacaoBuilder();
            amigo.Localizacao = localizacao.Novo(endereco).Criar();
            return this;
        }

        public AmigoBuilder CheckarMinhaLocalizacao() {
            amigo.EstouAqui = true;
            return this;
        }

        public Amigo Criar() {
            return amigo;
        }
    }
}
