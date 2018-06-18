using MootIT.Processo.Core.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MootIT.Processo.Core.Servico
{
    public class ServicoGoogleMaps
    {
        public Tuple<double,double> ObterCoordenadas(string endereco)
        {
            var googleMapsURL = string.Format(ObterURLServico(), endereco);
            var result = new System.Net.WebClient().DownloadString(googleMapsURL);

            var googleResponse = JsonConvert.DeserializeObject<GoogleGeoCodeResponse>(result);

            if (googleResponse.results.Length == 0) throw new Exception("Não foram encontradas as coordenadas para o endereço informado. (Verifique limite de requisições da API do GoogleMaps)");

            var firstLocation = googleResponse.results[0].geometry.location;
            var latitude = Convert.ToDouble(firstLocation.lat.Replace(".", ","));
            var longitude = Convert.ToDouble(firstLocation.lng.Replace(".", ","));

            return new Tuple<double, double>(latitude, longitude);
        }

        private string ObterURLServico()
        {
            return @"http://maps.google.com/maps/api/geocode/json?address={0}&sensor=false";
        }
    }
}
