using PublicTransportation.Application.Mappers;
using PublicTransportation.Domain.DTO.Create;
using PublicTransportation.Domain.DTO.Edit;
using PublicTransportation.Domain.DTO.Response;
using PublicTransportation.Domain.Entities;
using PublicTransportation.Domain.Exceptions;
using PublicTransportation.Domain.Interfaces.Repositories;
using PublicTransportation.Domain.Utils;

namespace PublicTransportation.Application.UseCases.Lines
{
    public class LineServices
    {
        public readonly ILineRepository _lineRepository;

        public LineServices(ILineRepository lineRepository)
        {
            _lineRepository = lineRepository;
        }

        public GetAllResponse<LineResponseDTO> Search(LineSearchParameters parameters)
        {
            var getAllResponse = new GetAllResponse<LineResponseDTO>();
            getAllResponse.SearchParameters = parameters;

            var query = _lineRepository.Queryable();

            getAllResponse.TotalCount = _lineRepository.Count();

            
            query = ApplyFilter(query, parameters.SearchString);
            query = ApplyOrder(query, parameters.OrderType);


            query = query.Skip(parameters.PerPage * parameters.CurrentPage).Take(parameters.PerPage);

            var result = query.ToList();

            getAllResponse.Rows = result.ToResponseDTO();

            return getAllResponse;
        }


        public LineResponseDTO GetById(long id)
        {
            var line = _lineRepository.GetById(id);

            if (line is null) throw new NotFoundException("Record not found.");

            return line.ToResponseDTO();
        }

        public void Create(CreateLineDTO dto)
        {
            var line = new Line
            {
                Name = dto.Name,
            };

            _lineRepository.Create(line);
            _lineRepository.Commit();
        }

        public void Update(UpdateLineDTO dto, long id)
        {
            var line = _lineRepository.GetById(id);

            if (line is null) throw new NotFoundException("Record not found.");

            line.Name = dto.Name;

            _lineRepository.Update(line);
            _lineRepository.Commit();
        }

        public void Delete(long id)
        {
            var oldLine = _lineRepository.GetById(id);

            if (oldLine is null) throw new NotFoundException("Record not found.");

            _lineRepository.Delete(oldLine);
            _lineRepository.Commit();
        }



        private IQueryable<Line> ApplyFilter(IQueryable<Line> query, string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
                query = query.Where(x => x.Name.Contains(searchString));

            return query;
        }
        private IQueryable<Line> ApplyOrder(IQueryable<Line> query, string orderType)
        {
            query = orderType == "desc"
                ? query.OrderByDescending(x => x.Name)
                : query.OrderBy(x => x.Name);
            
            return query;
        }
    }
}
