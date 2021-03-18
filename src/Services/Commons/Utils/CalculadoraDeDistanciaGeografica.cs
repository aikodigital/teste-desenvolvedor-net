using System;
using Domain.ValueObjects;
using Services.Commons.Extensions;
using Services.Interfaces;

namespace Services.Commons.Utils
{
    public class CalculadoraDeDistanciaGeografica : IServiceScoped
    {
        public double HaversineDistance(Localizacao pos1, Localizacao pos2)
        {
            double raioTerrestre = 6371000;

            var dLat = (pos2.Latitude - pos1.Latitude).ToRadians();
            var dLon = (pos2.Longitude - pos1.Longitude).ToRadians();

            var lat1 = pos1.Latitude.ToRadians();
            var lat2 = pos2.Latitude.ToRadians();

            var formulaHaversine = Math.Pow(Math.Sin(dLat / 2), 2) +
                       Math.Pow(Math.Sin(dLon / 2), 2) *
                       Math.Cos(lat1) * Math.Cos(lat2);

            var c = 2 * Math.Asin(Math.Sqrt(formulaHaversine));

            var distancia = raioTerrestre * c;

            return distancia;
        }
    }
}