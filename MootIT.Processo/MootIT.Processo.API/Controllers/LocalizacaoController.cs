using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MootIT.Processo.API.Contract;
using MootIT.Processo.API.Interface;
using MootIT.Processo.API.Transformation;
using MootIT.Processo.Core;
using MootIT.Processo.Core.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MootIT.Processo.API.Controllers
{
    [Route("api/localizacao")]
    public class LocalizacaoController : Controller
    {

        [HttpPost]
        public JsonResult Post([FromBody] IEnumerable<Amigo> amigos)
        {
            var parametro = Conversao.Transformar(amigos) as List<Core.DTO.Amigo>;
            var resultado = LocalizacaoCore.Executar(parametro);
            var retorno = Conversao.Transformar(resultado);
            return Json(retorno);
        }

        private Interface.ITransformation<Amigo> conversao;
        public Interface.ITransformation<Amigo> Conversao
        {
            get => conversao ?? new TransformacaoAmigo();
            set => conversao = value;
        }

        private ILocalizarAmigoMaisProximo<Core.DTO.Amigo> localizacaoCore;
        public ILocalizarAmigoMaisProximo<Core.DTO.Amigo> LocalizacaoCore
        {
            get => localizacaoCore ?? new LocalizarAmigoMaisProximo();
            set => localizacaoCore = value;
        }
    }
}
