using PublicTransportation.Application.Mappers;
using PublicTransportation.Domain.DTO.Create;
using PublicTransportation.Domain.DTO.Edit;
using PublicTransportation.Domain.DTO.Response;
using PublicTransportation.Domain.Entities;
using PublicTransportation.Domain.Exceptions;
using PublicTransportation.Domain.Interfaces.Repositories;
using PublicTransportation.Domain.Utils;

namespace PublicTransportation.Application.UseCases.Vehicles
{
    public class VehicleServices
    {
        public readonly IVehicleRepository _vehicleRepository;

        public VehicleServices(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public GetAllResponse<VehicleResponseDTO> Search(VehicleSearchParameters parameters)
        {
            var getAllResponse = new GetAllResponse<VehicleResponseDTO>();
            getAllResponse.SearchParameters = parameters;

            var query = _vehicleRepository.Queryable();
            query = _vehicleRepository.AsNoTracking(query);
            query = _vehicleRepository.ApplyIncludes(query);
            

            getAllResponse.TotalCount = _vehicleRepository.Count();
            
            query = ApplyFilter(query, parameters);
            query = ApplyOrder(query, parameters.OrderType);
            
            query = query.Skip(parameters.PerPage * parameters.CurrentPage).Take(parameters.PerPage);

            var result = query.ToList();

            getAllResponse.Rows = result.ToResponseDTO();

            return getAllResponse;
        }


        public VehicleResponseDTO GetById(long id)
        {
            var stop = _vehicleRepository.GetById(id);

            if (stop is null) throw new NotFoundException("Record not found.");

            return stop.ToResponseDTO();
        }

        public void Create(CreateVehicleDTO dto)
        {
            var vehicle = new Vehicle
            {
                Name = dto.Name,
                Model = dto.Model,
                LineId = dto.LineId,
            };

            _vehicleRepository.Create(vehicle);
            _vehicleRepository.Commit();
        }

        public void Update(UpdateVehicleDTO dto, long id)
        {
            var vehicle = _vehicleRepository.GetById(id);

            if (vehicle is null) throw new NotFoundException("Record not found.");

            vehicle.Name = dto.Name;
            vehicle.Model = dto.Model;
            vehicle.LineId = dto.LineId;

            _vehicleRepository.Update(vehicle);
            _vehicleRepository.Commit();
        }

        public void Delete(long id)
        {
            var vehicle = _vehicleRepository.GetById(id);

            if (vehicle is null) throw new NotFoundException("Record not found.");

            var vehiclePosition = _vehicleRepository.GetVehiclePositionByVehicleId(vehicle.Id);

            if(vehiclePosition is not null)
                _vehicleRepository.DeleteVehiclePosition(vehiclePosition);

            _vehicleRepository.Delete(vehicle);
            _vehicleRepository.Commit();
        }


        public void CreateVehiclePosition(CreateVehiclePositionDTO dto, long vehicleId)
        {
            if (_vehicleRepository.VehicleHasPosition(vehicleId))
                throw new BadRequestException("This vehicle already has a position.");

            var vehiclePosition = new VehiclePosition
            {
                VehicleId = vehicleId,
                Latitude = dto.Latitude,
                Longitude = dto.Logitude
            };

            _vehicleRepository.CreateVehiclePosition(vehiclePosition);
            _vehicleRepository.Commit();
        }

        public void UpdateVehiclePosition(UpdateVehiclePositionDTO dto, long vehicleId)
        {
            var vehiclePosition = _vehicleRepository.GetVehiclePositionByVehicleId(vehicleId);
            if (vehiclePosition is null)
                throw new NotFoundException("Record not found.");

            vehiclePosition.Longitude = dto.Logitude;
            vehiclePosition.Latitude = dto.Latitude;

            _vehicleRepository.UpdateVehiclePosition(vehiclePosition);
            _vehicleRepository.Commit();
        }

        public void DeleteVehiclePosition(long vehicleId)
        {
            var vehiclePosition = _vehicleRepository.GetVehiclePositionByVehicleId(vehicleId);
            if (vehiclePosition is null)
                throw new NotFoundException("Record not found.");

            _vehicleRepository.DeleteVehiclePosition(vehiclePosition);
            _vehicleRepository.Commit();
        }


        private IQueryable<Vehicle> ApplyFilter(IQueryable<Vehicle> query, VehicleSearchParameters parameters)
        {
            if (!string.IsNullOrEmpty(parameters.SearchString))
                query = query.Where(x => x.Name.Contains(parameters.SearchString) || x.Model.Contains(parameters.SearchString));

            return query;
        }

        private IQueryable<Vehicle> ApplyOrder(IQueryable<Vehicle> query, string orderType)
        {
            query = orderType == "desc"
                ? query.OrderByDescending(x => x.Name)
                : query.OrderBy(x => x.Name);
            
            return query;
        }
    }
}
