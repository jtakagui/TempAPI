using MootIT.Processo.Core.Interface;
using System;
using MootIT.Processo.Core.DTO;
using System.Collections.Generic;
using MootIT.Processo.Core.Extension;
using System.Linq;
using MootIT.Processo.Core.Transforma;
using MootIT.Processo.Repositorio.Interface;

namespace MootIT.Processo.Core
{
    public class LocalizarAmigoMaisProximo : ILocalizarAmigoMaisProximo<Amigo>
    {
        public IEnumerable<Amigo> Executar(IEnumerable<Amigo> amigos) {
            amigos.ValidarDuplicidade();

            var minhaLocalizacao = amigos.Where(amigo => amigo.EstouAqui).First();
            var amigosMaisProximos = amigos.Where(amigo => amigo.Nome != minhaLocalizacao.Nome);
            
            amigosMaisProximos.ToList().ForEach(amigo =>
            {
                amigo.Localizacao.CarregarCoordenadas();
                amigo.Localizacao.CalcularDistancia(minhaLocalizacao.Localizacao.Latitude, minhaLocalizacao.Localizacao.Longitude);
            });

            var resultado = amigosMaisProximos.OrderBy(amigo => amigo.Localizacao.Distancia);

            var parametro = (Repositorio.Collection.CalculoHistoricoLog)Conversao.Transformar(resultado);
            AmigoRepositorio.Incluir(parametro);

            return resultado.Take(3);
        }

        private ITransformation<Amigo> conversao;
        public ITransformation<Amigo> Conversao
        {
            get => conversao ?? new TransformacaoAmigo();
            set => conversao = value;
        }

        private IRepositorio<Repositorio.Collection.CalculoHistoricoLog> amigoRepositorio;
        public IRepositorio<Repositorio.Collection.CalculoHistoricoLog> AmigoRepositorio
        {
            get => amigoRepositorio ?? new Repositorio.CalculoHistoricoLogRepositorio();
            set => AmigoRepositorio = value;
        }
    }
}
