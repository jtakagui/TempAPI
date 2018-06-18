using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MootIT.Processo.API.Contract
{
    public class Amigo
    {
        public string Nome { get; set; }
        public Localizacao Localizacao { get; set; }
        public Boolean EstouAqui { get; set; }
    }
}
