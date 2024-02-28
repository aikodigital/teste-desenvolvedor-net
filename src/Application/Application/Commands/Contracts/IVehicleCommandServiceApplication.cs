using Application.Requests;
using Application.Responses;
using SharedKernel.Application.Result;
using System.Threading.Tasks;

namespace Application.Commands.Contracts
{
    public interface IVehicleCommandServiceApplication
    {
        Task<ResultApi<VehicleResponse>> Create(CreateVehicleRequest vehicleRequest);
        Task<ResultApi<VehicleResponse>> Update(UpdateVehicleRequest vehicleRequest);
        Task<ResultApi<VehicleResponse>> Delete(DeleteVehicleRequest vehicleRequest);
    }
}
