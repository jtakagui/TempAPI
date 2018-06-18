using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MootIT.Processo.Repositorio.Interface;

namespace MootIT.Processo.Repositorio.Collection
{
    public class CalculoHistoricoLog: IColletionRepositorio
    {
        public DateTime Data { get; set; }
        public IEnumerable<Amigo> HistoricoCalculoLocalizacao { get; set; }
    }
}
