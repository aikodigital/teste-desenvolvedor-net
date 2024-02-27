using Application.Requests;
using Application.Responses;
using SharedKernel.Application.Result;
using System.Threading.Tasks;

namespace Application.Commands.Contracts
{
    public interface IVehiclePositionCommandServiceApplication
    {
        Task<ResultApi<VehiclePositionResponse>> Create(CreateVehiclePositionRequest vehiclePositionRequest);
        Task<ResultApi<VehiclePositionResponse>> Update(UpdateVehiclePositionRequest vehiclePositionRequest);
        Task<ResultApi<VehiclePositionResponse>> Delete(DeleteVehiclePositionRequest vehiclePositionRequest);
    }
}
