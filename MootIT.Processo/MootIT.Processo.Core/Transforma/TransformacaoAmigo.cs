using MootIT.Processo.Core.DTO;
using MootIT.Processo.Core.Interface;
using MootIT.Processo.Repositorio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MootIT.Processo.Core.Transforma
{
    public class TransformacaoAmigo : Transformation<Amigo>, ITransformation<Amigo>
    {
        public override IColletionRepositorio Transformar(IEnumerable<Amigo> core)
        {
            var amigoCollection = new Repositorio.Builder.CalculoHistoricoLogBuilder();

            core.ToList().ForEach(amigo => {
                amigoCollection.Adicionar(amigo.Nome, amigo.Localizacao.Endereco, amigo.Localizacao.Latitude, amigo.Localizacao.Longitude, amigo.Localizacao.Distancia, amigo.EstouAqui);
            });

            return amigoCollection.Criar();
        }

        public override IColletionRepositorio Transformar(Amigo core)
        {
            var amigoCollection = new Repositorio.Builder.CalculoHistoricoLogBuilder();
            return amigoCollection.Adicionar(core.Nome, core.Localizacao.Endereco, core.Localizacao.Latitude, core.Localizacao.Longitude, core.Localizacao.Distancia, core.EstouAqui).Criar();

        }
    }
}
