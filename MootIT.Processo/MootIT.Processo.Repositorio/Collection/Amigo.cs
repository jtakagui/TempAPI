using MootIT.Processo.Repositorio.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MootIT.Processo.Repositorio.Collection
{
    public class Amigo: IColletionRepositorio
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Distancia { get; set; }
        public Boolean EstouAqui { get; set; }
    }
}
