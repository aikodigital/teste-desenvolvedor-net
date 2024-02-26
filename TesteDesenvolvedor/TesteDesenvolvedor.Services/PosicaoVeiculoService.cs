using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using TesteDesenvolvedor.Domain;
using TesteDesenvolvedor.Repository.Interface;
using TesteDesenvolvedor.Services.DTOs;
using TesteDesenvolvedor.Services.Interface;

namespace TesteDesenvolvedor.Services
{
    public class PosicaoVeiculoService : IPosicaoVeiculoService
    {
          private readonly IPosicaoVeiculoRepository _repository;
          private readonly IMapper _mapper;

        public PosicaoVeiculoService(IPosicaoVeiculoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<PosicaoVeiculoDTO> FindByIdPosicaoVeiculoAsync(long veiculoId)
        {
            try
            {
                var result = await _repository.FindByIdVeiculoAsync(veiculoId);
                if (result == null) return null;

                return _mapper.Map<PosicaoVeiculoDTO>(result);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<PosicaoVeiculoDTO> AddPosicaoVeiculoAsync(PosicaoVeiculoDTO posicaoVeiculoDTO)
        {
            try
            {
                var posicaoVeiculo = _mapper.Map<PosicaoVeiculo>(posicaoVeiculoDTO);
                _repository.Add(posicaoVeiculo);
                return await _repository.SaveChangesAsync() ?
                    _mapper.Map<PosicaoVeiculoDTO>(await _repository.FindByIdAsync(posicaoVeiculo.VeiculoId)) :
                    null;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar a PosicaoVeiculo: " + ex.Message);
            }
        }

        public async Task<bool> DeletePosicaoVeiculoAsync(long veiculoId)
        {
           try{
               var result = await _repository.FindByIdVeiculoAsync(veiculoId);
               if(result == null) throw new Exception("PosicaoVeiculo não encontrada");

               _repository.Delete(result);
               return await _repository.SaveChangesAsync();

           }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<PosicaoVeiculoDTO>> GetAllPosicaoVeiculosAsync()
        {
           try{
               
               var result = await _repository.GetAllAsync();
               if (result == null) return null;
               return _mapper.Map<List<PosicaoVeiculoDTO>>(result);

           }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PosicaoVeiculoDTO> UpdatePosicaoVeiculoAsync(long veiculoId, PosicaoVeiculoDTO posicaoVeiculoDTO)
        {

            try
            {
                var posicaoVeiculo = _mapper.Map<PosicaoVeiculo>(posicaoVeiculoDTO);
                var posicao = await _repository.FindByIdVeiculoAsync(veiculoId);
                var result = await _repository.FindByIdAsync(posicao.Id);
                if (result == null) throw new Exception("Posicao do Veiculo não encontrada");

                posicaoVeiculo.Id = result.Id;
                _repository.Update(posicaoVeiculo);
                if(await _repository.SaveChangesAsync()){
                    return _mapper.Map<PosicaoVeiculoDTO>(await _repository.FindByIdVeiculoAsync(veiculoId));
                }
                return null;

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}