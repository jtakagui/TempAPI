using MootIT.Processo.Core.DTO;
using MootIT.Processo.Core.Servico;
using System;
using System.Collections.Generic;
using System.Text;

namespace MootIT.Processo.Core.Extension
{
    public static class LocalizacaoExtension
    {
        public static void CalcularDistancia(this Localizacao amigo, double minhaLatitude, double minhaLongitude)
        {

            const double metros = 6371;

            var sdlat = Math.Sin((minhaLatitude - amigo.Latitude) / 2);
            var sdlon = Math.Sin((minhaLongitude - amigo.Longitude) / 2);
            var q = sdlat * sdlat + Math.Cos(amigo.Latitude) * Math.Cos(minhaLatitude) * sdlon * sdlon;
            var distancia = 2 * metros * Math.Asin(Math.Sqrt(q));

            amigo.Distancia = distancia;

        }

        public static void CarregarCoordenadas(this Localizacao localizacao) {
            var google = new ServicoGoogleMaps();
            var coordenadas = google.ObterCoordenadas(localizacao.Endereco);

            localizacao.Latitude = coordenadas.Item1;
            localizacao.Longitude = coordenadas.Item2;
        }
    }
}
