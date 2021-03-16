using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.ValueObjects;
using Infra;
using Microsoft.EntityFrameworkCore;
using Services.Commons;
using Services.Commons.Utils;

namespace Services.Parada
{
    public class ListarParadasMaisProximas : BaseService
    {
        private readonly CalculadoraDeDistanciaGeografica calculadoraDeDistanciaGeografica;

        public ListarParadasMaisProximas(ApplicationContext context, CalculadoraDeDistanciaGeografica calculadoraDeDistanciaGeografica) : base(context)
        {
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