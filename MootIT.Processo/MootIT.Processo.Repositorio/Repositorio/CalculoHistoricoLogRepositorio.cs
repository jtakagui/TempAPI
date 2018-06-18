using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MootIT.Processo.Repositorio.Collection;
using MootIT.Processo.Repositorio.Interface;
using System;
using System.IO;

namespace MootIT.Processo.Repositorio
{
    public class CalculoHistoricoLogRepositorio : IRepositorio<CalculoHistoricoLog>
    {
        private string ObterStringConexao()
        {
            return AppSettingsJson.GetAppSettings().GetSection("ConnectionString").Value;
        }

        protected IMongoClient ClientMongoDB
        {
            get
            {
                var client = new MongoClient(ObterStringConexao());
                return client;
            }
        }

        protected IMongoDatabase MongoDB
        {
            get
            {
                var db = ClientMongoDB.GetDatabase("moottest");
                return db;
            }
        }

        public void Incluir(CalculoHistoricoLog calculoHistoricoLog)
        {
            var log = MongoDB.GetCollection<CalculoHistoricoLog>("calculoHistoricoLog");

            log.InsertOne(calculoHistoricoLog);


        }
    }

    public static class AppSettingsJson
    {
        public static string ApplicationExeDirectory()
        {
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var appRoot = Path.GetDirectoryName(location);

            return appRoot;
        }

        public static IConfigurationRoot GetAppSettings()
        {
            string applicationExeDirectory = ApplicationExeDirectory();

            var builder = new ConfigurationBuilder()
            .SetBasePath(applicationExeDirectory)
            .AddJsonFile("appsettings.json");

            return builder.Build();
        }
    }
}
