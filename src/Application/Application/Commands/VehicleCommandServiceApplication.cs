using Application.Commands.Contracts;
using Application.Requests;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using Domain.Services.Contracts;
using SharedKernel.Application.Result;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class VehicleCommandServiceApplication : IVehicleCommandServiceApplication
    {
        protected readonly IVehicleServices _service;
        protected readonly IMapper _mapper;

        public VehicleCommandServiceApplication(IVehicleServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<ResultApi<VehicleResponse>> Create(CreateVehicleRequest vehicleRequest)
        {
            Vehicle model = await _service.Add(_mapper.Map<Vehicle>(vehicleRequest));
            return new ResultApi<VehicleResponse>
            {
                Success = true,
                Data = _mapper.Map<VehicleResponse>(model)
            };
        }

        public async Task<ResultApi<VehicleResponse>> Delete(DeleteVehicleRequest vehicleRequest)
        {
            _service.Delete(_mapper.Map<Vehicle>(vehicleRequest));
            return new ResultApi<VehicleResponse>
            {
                Success = true
            };
        }

        public async Task<ResultApi<VehicleResponse>> Update(UpdateVehicleRequest vehicleRequest)
        {
            Vehicle model = _service.Update(_mapper.Map<Vehicle>(vehicleRequest));
            return new ResultApi<VehicleResponse>
            {
                Success = true,
                Data = _mapper.Map<VehicleResponse>(model)
            };
        }
    }
}
