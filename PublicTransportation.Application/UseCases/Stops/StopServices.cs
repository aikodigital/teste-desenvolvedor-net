using PublicTransportation.Application.Extensions;
using PublicTransportation.Application.Mappers;
using PublicTransportation.Domain.DTO.Create;
using PublicTransportation.Domain.DTO.Edit;
using PublicTransportation.Domain.DTO.Response;
using PublicTransportation.Domain.Entities;
using PublicTransportation.Domain.Exceptions;
using PublicTransportation.Domain.Interfaces.Repositories;
using PublicTransportation.Domain.Utils;

namespace PublicTransportation.Application.UseCases.Stops
{
    public class StopServices
    {
        public readonly IStopRepository _stopRepository;

        public StopServices(IStopRepository stopRepository)
        {
            _stopRepository = stopRepository;
        }

        public GetAllResponse<StopResponseDTO> Search(StopSearchParameters parameters)
        {
            var getAllResponse = new GetAllResponse<StopResponseDTO>();
            getAllResponse.SearchParameters = parameters;

            var query = _stopRepository.Queryable();

            getAllResponse.TotalCount = _stopRepository.Count();

            
            query = ApplyFilter(query, parameters);
            query = ApplyOrder(query, parameters.OrderType);


            query = query.Skip(parameters.PerPage * parameters.CurrentPage).Take(parameters.PerPage);

            var result = query.ToList();

            getAllResponse.Rows = result.ToResponseDTO();

            return getAllResponse;
        }


        public StopResponseDTO GetById(long id)
        {
            var stop = _stopRepository.GetById(id);

            if (stop is null) throw new NotFoundException("Record not found.");

            return stop.ToResponseDTO();
        }

        public void Create(CreateStopDTO dto)
        {
            var stop = new Stop
            {
                Name = dto.Name,
                Latitude = dto.Latitude,
                Longitude = dto.Longitude,
            };

            _stopRepository.Create(stop);
            _stopRepository.Commit();
        }

        public void Update(UpdateStopDTO dto, long id)
        {
            var stop = _stopRepository.GetById(id);

            if (stop is null) throw new NotFoundException("Record not found.");

            stop.Name = dto.Name;
            stop.Latitude = dto.Latitude;
            stop.Longitude = dto.Longitude;


            _stopRepository.Update(stop);
            _stopRepository.Commit();
        }

        public void Delete(long id)
        {
            var stop = _stopRepository.GetById(id);

            if (stop is null) throw new NotFoundException("Record not found.");

            var lineStops = _stopRepository.GetAllLineStopByStopId(id);

            if (!lineStops.IsNullOrEmpty())
                _stopRepository.RemoveRangeLineStop(lineStops);

            _stopRepository.Delete(stop);
            _stopRepository.Commit();
        }


        public StopResponseDTO GetByIdWithLines(long id)
        {
            var stop = _stopRepository.GetByIdWithLines(id);

            if (stop is null) throw new NotFoundException("Record not found.");

            return stop.ToResponseDTO();
        }


        public ICollection<StopResponseDTO> GetClosestStops(double latitude, double longitude)
        {
            var stops = _stopRepository.GetClosestStops(latitude, longitude);
            return stops.ToResponseDTO();
        }


        #region SearchMethods
        private IQueryable<Stop> ApplyFilter(IQueryable<Stop> query, StopSearchParameters parameters)
        {
            if (!string.IsNullOrEmpty(parameters.SearchString))
                query = query.Where(x => x.Name.Contains(parameters.SearchString));

            if (parameters.Longitude is not null)
                query = query.Where(x => x.Longitude == parameters.Longitude);

            if (parameters.Latitude is not null)
                query = query.Where(x => x.Latitude == parameters.Latitude);

            return query;
        }

        private IQueryable<Stop> ApplyOrder(IQueryable<Stop> query, string orderType)
        {
            query = orderType == "desc"
                ? query.OrderByDescending(x => x.Name)
                : query.OrderBy(x => x.Name);
            
            return query;
        }
        #endregion
    }
}
