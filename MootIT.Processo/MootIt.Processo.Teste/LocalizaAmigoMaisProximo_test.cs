using Microsoft.VisualStudio.TestTools.UnitTesting;
using MootIT.Processo.Core;
using MootIT.Processo.Core.Builder;
using MootIT.Processo.Core.DTO;
using MootIT.Processo.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MootIt.Processo.Teste
{
    [TestClass]
    public class LocalizaAmigoMaisProximo_test
    {
        private ILocalizarAmigoMaisProximo<Amigo> coreClass;

        [TestInitialize]
        public void Inicio() {
            coreClass = new LocalizarAmigoMaisProximo();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ValidouDuplicidadeDeEndereco() {
            var amigo1 = new AmigoBuilder()
                .Novo("João")
                .ComLocalizacao("Rua Treze de Maio, 1633 Bela Vista - São Paulo - SP 01327-905")
                .Criar();

            var amigoVisitado = new AmigoBuilder()
                .Novo("Tonho")
                .ComLocalizacao("Rua Treze de Maio, 1633 Bela Vista - São Paulo - SP 01327-905")
                .CheckarMinhaLocalizacao()
                .Criar();

            var amigos = new List<Amigo>() { amigoVisitado, amigo1 };

            var amigoMaisProximo = coreClass.Executar(amigos).ToArray();
        }

        [TestMethod]
        public void LocalizouAmigoMaisProximo() {

            var amigo1 = new AmigoBuilder()
                .Novo("João")
                .ComLocalizacao("Rua da consolacao, 3638 - Cerqueira Cesar - São Paulo - SP 01416-906")
                .Criar();

            var amigo2 = new AmigoBuilder()
                .Novo("Zé")
                .ComLocalizacao("Rua Treze de Maio 1933 - Bela Vista - São Paulo - SP 04849-529")
                .Criar();

            var amigo3 = new AmigoBuilder()
                .Novo("Tinho")
                .ComLocalizacao("Rua Haddock Lobo, 131 - Cerqueira César - São Paulo - SP 01414-001")
                .Criar();

            var amigo4 = new AmigoBuilder()
                .Novo("Lalá")
                .ComLocalizacao("Rua Félix da Cunha, 41 Tijuca - Rio de Janeiro - RJ 20260-300")
                .Criar();

            var amigo5 = new AmigoBuilder()
                .Novo("DaGema")
                .ComLocalizacao("Avenida Rio Branco, 243 Centro - Rio de Janeiro - RJ 20040-009")
                .Criar();

            var amigo6 = new AmigoBuilder()
                .Novo("Vasco")
                .ComLocalizacao("Avenida Venezuela, 134 Saúde - Rio de Janeiro - RJ 20081-312")
                .Criar();

            var amigo7 = new AmigoBuilder()
                .Novo("Isqueiro")
                .ComLocalizacao("Rua Manaí, 81 Campo Grande - Rio de Janeiro - RJ 23052-220")
                .Criar();

            var amigoVisitado = new AmigoBuilder()
                .Novo("Tonho")
                .ComLocalizacao("Rua Treze de Maio, 1633 - Bela Vista - São Paulo - SP 01327-905")
                .CheckarMinhaLocalizacao()
                .Criar();

            var amigos = new List<Amigo>() { amigoVisitado, amigo1, amigo2 , amigo3/*, amigo4, amigo5, amigo6, amigo7 */ };
            
            var amigoMaisProximo = coreClass.Executar(amigos).ToArray();
            
            Assert.AreEqual(amigo3, amigoMaisProximo[0]);
            Assert.AreEqual(amigo1, amigoMaisProximo[1]);
            Assert.AreEqual(amigo2, amigoMaisProximo[2]);

        }
    }
}
