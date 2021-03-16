using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.ValueObjects;
using Infra;
using Microsoft.EntityFrameworkCore;
using Services.Commons.Utils;
using Services.Interfaces;

namespace Services.Parada
{
    public class ListarParadasMaisProximas : IServiceScoped
    {
        private readonly ApplicationContext context;
        private readonly CalculadoraDeDistanciaGeografica calculadoraDeDistanciaGeografica;

        public ListarParadasMaisProximas(ApplicationContext context, CalculadoraDeDistanciaGeografica calculadoraDeDistanciaGeografica)
        {
            this.context = context;
            this.calculadoraDeDistanciaGeografica = calculadoraDeDistanciaGeografica;
        }

        public async Task<List<Domain.Entities.Parada>> Executar(double latitude, double longitude, int raioEmMetros)
        {
            var paradasMaisProximas = new List<Domain.Entities.Parada>();

            var paradas = await context.Paradas.ToListAsync();

            foreach (var item in paradas) {
                var distancia = calculadoraDeDistanciaGeografica.HaversineDistance(new Localizacao(latitude, longitude), item.Localizacao);

                if (distancia < raioEmMetros) {
                    paradasMaisProximas.Add(item);
                }
            }

            return paradasMaisProximas;
        }
    }
}