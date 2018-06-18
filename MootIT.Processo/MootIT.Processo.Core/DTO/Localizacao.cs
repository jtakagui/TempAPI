using MootIT.Processo.Core.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MootIT.Processo.Core.DTO
{
    public class Localizacao : IDTO
    {
        public string Endereco { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Distancia { get; set; }
    }
}
