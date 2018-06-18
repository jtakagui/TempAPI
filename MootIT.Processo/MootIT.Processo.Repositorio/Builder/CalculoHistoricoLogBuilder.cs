using MootIT.Processo.Repositorio.Collection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MootIT.Processo.Repositorio.Builder
{
    public class CalculoHistoricoLogBuilder
    {
        private CalculoHistoricoLog calculoHistoricoLog;
        private IList<Repositorio.Collection.Amigo> historicoCalculoLocalizacao; 

        public CalculoHistoricoLogBuilder() {
            calculoHistoricoLog = new CalculoHistoricoLog();
            historicoCalculoLocalizacao = new List<Repositorio.Collection.Amigo>();
        }

        public CalculoHistoricoLogBuilder Adicionar(string nome, string endereco,
        double latitude, double longitude, double distancia, Boolean estouAqui)
        {
            historicoCalculoLocalizacao.Add(
            new Amigo {
                Nome = nome,
                Endereco = endereco,
                Latitude = latitude,
                Longitude = longitude,
                Distancia = distancia,
                EstouAqui = estouAqui
            });
            return this;
        }

        public CalculoHistoricoLog Criar() {
            calculoHistoricoLog.Data = DateTime.Now;
            calculoHistoricoLog.HistoricoCalculoLocalizacao = historicoCalculoLocalizacao;
            return calculoHistoricoLog;
        }


    }
}
