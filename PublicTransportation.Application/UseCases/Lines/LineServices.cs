using PublicTransportation.Application.Extensions;
using PublicTransportation.Application.Mappers;
using PublicTransportation.Application.UseCases.Vehicles;
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
        private readonly ILineRepository _lineRepository;
        private readonly VehicleServices _vehicleServices;

        public LineServices(ILineRepository lineRepository, VehicleServices vehicleServices)
        {
            _lineRepository = lineRepository;
            _vehicleServices = vehicleServices;
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

            if (!dto.Stops.IsNullOrEmpty())
            {
                line.LinesStops = new List<LineStop>();
                foreach (var stop in dto.Stops)
                {
                    line.LinesStops.Add(new LineStop { StopId = stop.StopId });
                }  
            }

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
            var line = _lineRepository.GetById(id);

            if (line is null) throw new NotFoundException("Record not found.");

            var hasVehicles = _vehicleServices.HasVehiclesInLine(id);

            if (hasVehicles) throw new BadRequestException("You can't delete it because there are vehicles using this record.");

            var lineStops = _lineRepository.GetAllLineStopByLineId(id);

            if (!lineStops.IsNullOrEmpty())
                _lineRepository.RemoveRangeLineStop(lineStops);

            _lineRepository.Delete(line);
            _lineRepository.Commit();
        }

        public void RemoveStop(long lineId, long stopId)
        {
            var lineStop = _lineRepository.GetLineStopByLineIdStopId(lineId, stopId);

            if (lineStop is null) throw new NotFoundException("Record not found.");

            _lineRepository.RemoveLineStop(lineStop);
            _lineRepository.Commit();
        }

        public LineResponseDTO GetByIdWithVehicles(long id)
        {
            var line = _lineRepository.GetByIdWithVehicles(id);

            if (line is null) throw new NotFoundException("Record not found.");

            return line.ToResponseDTO();
        }


        #region SearchMethods
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
        #endregion
    }
}
