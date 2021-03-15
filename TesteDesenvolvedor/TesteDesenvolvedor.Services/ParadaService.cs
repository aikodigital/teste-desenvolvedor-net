using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using TesteDesenvolvedor.Domain;
using TesteDesenvolvedor.Repository.Interface;
using TesteDesenvolvedor.Services.DTOs;
using TesteDesenvolvedor.Services.Interface;
using System.Globalization;
using TesteDesenvolvedor.Services.Utils;

namespace TesteDesenvolvedor.Services
{
    public class ParadaService : IParadaService
    {
        private readonly IParadaRepository _repository;
        private readonly IMapper _mapper;
        public ParadaService(IParadaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ParadaDTO> FindByIdParadaAsync(long id)
        {
            try
            {
                var result = await _repository.FindByIdAsync(id);
                if (result == null) return null;

                return _mapper.Map<ParadaDTO>(result);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<PageList<ParadaDTO>> FindByNameSearchPage(string nome, int page, int pageSize)
        {
            try
            {
                var sort = "asc";
                var size = (pageSize < 1) ? 10 : pageSize;
                var offset = page > 0 ? (page - 1) * size : 0;

                var students = await _repository.FindByNameSearchPage(nome, offset, size);
                var totalResult = _repository.GetCount(nome);
                var searchPage = new PageList<ParadaDTO>
                {
                    CurrentPage = page,
                    List = _mapper.Map<List<ParadaDTO>>(students),
                    PageSize = size,
                    SortDirections = sort,
                    TotalResults = totalResult
                };
                return searchPage;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao fazer paginação" + ex.Message);
            }
        }

        public async Task<ParadaDTO> AddParadaAsync(Parada parada)
        {
            try
            {
                // var parada = _mapper.Map<Parada>(paradaDTO);
                _repository.Add(parada);
                return await _repository.SaveChangesAsync() ?
                    _mapper.Map<ParadaDTO>(await _repository.FindByIdAsync(parada.Id)) :
                    null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteParadaAsync(long id)
        {
            try
            {
                var result = await _repository.FindByIdAsync(id);
                if (result == null) throw new Exception("Parada não encontrada");

                _repository.Delete(result);
                return await _repository.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ParadaDTO>> GetAllParadasAsync()
        {
            try
            {

                var result = await _repository.GetAllAsync();
                if (result == null) return null;
                return _mapper.Map<List<ParadaDTO>>(result); ;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ParadaDTO> UpdateParadaAsync(long id, ParadaDTO paradaDTO)
        {
            try
            {
                var parada = _mapper.Map<Parada>(paradaDTO);
                var result = await _repository.FindByIdAsync(id);

                if (result == null) throw new Exception("Parada não encontrada");

                parada.Id = result.Id;
                _repository.Update(parada);
                if (await _repository.SaveChangesAsync())
                {
                    return _mapper.Map<ParadaDTO>(await _repository.FindByIdAsync(id));
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ParadaPosicaoDTO>> FindParadaByPosicao(double lat, double lng, double distanciaBusca)
        {
            try
            {
                double distanceDefault = distanciaBusca == 0 ? 5 : distanciaBusca;
                var result = await _repository.FindParadaByPosicao(lat, lng, distanceDefault);
                var paradasDTO = _mapper.Map<List<ParadaPosicaoDTO>>(result);
                if (result == null) return null;
                foreach (var parada in paradasDTO)
                {
                    parada.Distancia = Convert.ToDouble(DistanciaAteParada(parada, lat, lng).ToString("F2", CultureInfo.InvariantCulture));
                }

                return paradasDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private double DistanciaAteParada(ParadaPosicaoDTO parada, double lat, double lng)
        {
            var d1 = lat * (Math.PI / 180.0);
            var num1 = lng * (Math.PI / 180.0);
            var d2 = parada.Latitude * (Math.PI / 180.0);
            var num2 = parada.Longitude * (Math.PI / 180.0) - num1;
            var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) + Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);

            //Distancia em M
            double distance = parada.Distancia = 6371.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3))) * 1000;

            return distance;

        }
    }
}