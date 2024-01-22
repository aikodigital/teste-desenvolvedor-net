using ApiTransporte.Core.Exceptions;
using ApiTransporte.Core.Models;
using ApiTransporte.Core.Repositories.Lines;

namespace ApiTransporte.Api.Lines.Services
{
    public class LineService : ILineService
    {
        private readonly ILineRepository _lineRepository;

        public LineService(ILineRepository lineRepository)
        {
            _lineRepository = lineRepository;
        }

        public Line Create(Line line)
        {
            return _lineRepository.Create(line);
        }

        public void DeleteById(long id)
        {
            if (!_lineRepository.ExistsById(id))
            {
                throw new CustomNotFoundException($"Line with id {id} not found");
            }
            _lineRepository.DeleteById(id);
        }

        public ICollection<Line> FindAll()
        {
            return _lineRepository.FindAll();
        }

        public Line FindById(long id)
        {
            var result = _lineRepository.FindById(id);
            if (result is null)
            {
                throw new CustomNotFoundException($"Line with id {id} not found");
            }
            return result;
        }

        public Line UpdateById(long id, Line line)
        {
            if (!_lineRepository.ExistsById(id))
            {
                throw new CustomNotFoundException($"Line with id {id} not found");
            }
            line.Id = id;
            var updateLine = _lineRepository.Update(line);
            return updateLine;
        }
    }
}
