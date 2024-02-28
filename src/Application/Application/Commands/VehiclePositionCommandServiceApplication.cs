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
    public class VehiclePositionCommandServiceApplication : IVehiclePositionCommandServiceApplication
    {
        protected readonly IVehiclePositionServices _service;
        protected readonly IMapper _mapper;

        public VehiclePositionCommandServiceApplication(IVehiclePositionServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<ResultApi<VehiclePositionResponse>> Create(CreateVehiclePositionRequest vehiclePositionRequest)
        {
            VehiclePosition model = await _service.Add(_mapper.Map<VehiclePosition>(vehiclePositionRequest));
            return new ResultApi<VehiclePositionResponse>
            {
                Success = true,
                Data = _mapper.Map<VehiclePositionResponse>(model)
            };
        }

        public async Task<ResultApi<VehiclePositionResponse>> Delete(DeleteVehiclePositionRequest vehiclePositionRequest)
        {
            _service.Delete(_mapper.Map<VehiclePosition>(vehiclePositionRequest));
            return new ResultApi<VehiclePositionResponse>
            {
                Success = true
            };
        }

        public async Task<ResultApi<VehiclePositionResponse>> Update(UpdateVehiclePositionRequest vehiclePositionRequest)
        {
            VehiclePosition model = _service.Update(_mapper.Map<VehiclePosition>(vehiclePositionRequest));
            return new ResultApi<VehiclePositionResponse>
            {
                Success = true,
                Data = _mapper.Map<VehiclePositionResponse>(model)
            };
        }
    }
}
