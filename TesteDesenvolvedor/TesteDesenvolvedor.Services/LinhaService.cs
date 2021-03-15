using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using TesteDesenvolvedor.Domain;
using TesteDesenvolvedor.Repository.Interface;
using TesteDesenvolvedor.Services.DTOs;
using TesteDesenvolvedor.Services.Interface;
using TesteDesenvolvedor.Services.Utils;

namespace TesteDesenvolvedor.Services
{
    public class LinhaService : ILinhaService
    {
        private readonly ILinhaRepository _repository;
        private readonly IMapper _mapper;

        public LinhaService(ILinhaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<LinhaDTO> FindByIdLinhaAsync(long id)
        {
            try
            {

                var result = await _repository.FindByIdAsync(id);
                if (result == null) return null;

                return _mapper.Map<LinhaDTO>(result);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<LinhaParadasDTO>> FindAllLinhasByParadasAsync(long paradaId)
        {
            try
            {
                var result = await _repository.FindAllLinhasByParadasAsync(paradaId);
          
                if (result == null) return null;
                return _mapper.Map<List<LinhaParadasDTO>>(result);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<List<LinhaDTO>> GetAllLinhasAsync()
        {
            try
            {

                var result = await _repository.GetAllAsync();
                if (result == null) return null;
                return _mapper.Map<List<LinhaDTO>>(result);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<PageList<LinhaDTO>> FindByNameSearchPage(string nome, int page, int pageSize)
        {
            try
            {
                var sort = "asc";
                var size = (pageSize < 1) ? 10 : pageSize;
                var offset = page > 0 ? (page - 1) * size : 0;

                var students = await _repository.FindByNameSearchPage(nome, offset, size);
                var totalResult = _repository.GetCount(nome);
                var searchPage = new PageList<LinhaDTO>
                {
                    CurrentPage = page,
                    List = _mapper.Map<List<LinhaDTO>>(students),
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

        public async Task<LinhaDTO> AddLinhaAsync(Linha linha)
        {
            try
            {
                _repository.Add(linha);
                return await _repository.SaveChangesAsync() ?
                     _mapper.Map<LinhaDTO>(await _repository.FindByIdAsync(linha.Id)) :
                    null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<LinhaDTO> UpdateLinhaAsync(long id, LinhaDTO linhaDTO)
        {
            try
            {
                var linha = _mapper.Map<Linha>(linhaDTO);
                var result = await _repository.FindByIdAsync(id);
                if (result == null) throw new Exception("Linha não encontrada");

                linha.Id = result.Id;
                _repository.Update(linha);
                if (await _repository.SaveChangesAsync())
                {
                    return _mapper.Map<LinhaDTO>(await _repository.FindByIdAsync(id));
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<bool> DeleteLinhaAsync(long id)
        {
            try
            {
                var result = await _repository.FindByIdAsync(id);
                if (result == null) throw new Exception("Linha não encontrada");

                _repository.Delete(result);
                return await _repository.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}