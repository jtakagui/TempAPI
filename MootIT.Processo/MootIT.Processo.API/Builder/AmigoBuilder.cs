﻿using MootIT.Processo.API.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MootIT.Processo.API.Builder
{
    public class AmigoBuilder
    {
        private Amigo amigo;

        public AmigoBuilder()
        {
            amigo = new Amigo();
        }

        public AmigoBuilder Novo(string nome)
        {
            amigo.Nome = nome;
            return this;
        }

        public AmigoBuilder ComLocalizacao(string endereco)
        {
            var localizacao = new LocalizacaoBuilder();
            amigo.Localizacao = localizacao.Novo(endereco).Criar();
            return this;
        }

        public AmigoBuilder CheckarMinhaLocalizacao()
        {
            amigo.EstouAqui = true;
            return this;
        }

        public Amigo Criar()
        {
            return amigo;
        }
    }
}
