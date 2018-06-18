using MootIT.Processo.API.Contract;
using MootIT.Processo.API.Interface;
using MootIT.Processo.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MootIT.Processo.API.Transformation
{
    public class TransformacaoAmigo : Transformation<Amigo>, Interface.ITransformation<Amigo>
    {
        public override IDTO Transformar(Amigo contrato)
        {
            var amigoBuilder = new Core.Builder.AmigoBuilder();
            var amigo = amigoBuilder.Novo(contrato.Nome)
                                    .ComLocalizacao(contrato.Localizacao.Endereco);

            if (contrato.EstouAqui) amigo.CheckarMinhaLocalizacao();

            return amigo.Criar();

        }

        public override Amigo Transformar(IDTO core)
        {
            var dto = (Core.DTO.Amigo)core;
            var amigoBuilder = new Builder.AmigoBuilder();
            var amigo = amigoBuilder.Novo(dto.Nome)
                                    .ComLocalizacao(dto.Localizacao.Endereco);

            if (dto.EstouAqui) amigo.CheckarMinhaLocalizacao();

            return amigo.Criar();

        }
    }
}
