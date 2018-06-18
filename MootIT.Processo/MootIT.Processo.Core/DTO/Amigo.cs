using MootIT.Processo.Core.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MootIT.Processo.Core.DTO
{
    public class Amigo : IDTO
    {
        public string Nome { get; set; }
        public Localizacao Localizacao { get; set; }
        public Boolean EstouAqui { get; set; }
    }
}
