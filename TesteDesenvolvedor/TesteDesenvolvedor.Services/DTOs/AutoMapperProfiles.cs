using System.Linq;
using AutoMapper;
using TesteDesenvolvedor.Domain;

namespace TesteDesenvolvedor.Services.DTOs
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Linha, LinhaDTO>().ReverseMap();

            CreateMap<Parada, ParadaDTO>().ReverseMap();

            CreateMap<Parada, ParadaPosicaoDTO>();

            CreateMap<PosicaoVeiculo, PosicaoVeiculoDTO>().ReverseMap();
            
            CreateMap<Veiculo, VeiculoDTO>().ReverseMap();
    
            CreateMap<Linha, LinhaParadasDTO>();

        }
    }
}