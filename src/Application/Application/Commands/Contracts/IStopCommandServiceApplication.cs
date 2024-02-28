using Application.Requests;
using Application.Responses;
using SharedKernel.Application.Result;
using System.Threading.Tasks;

namespace Application.Commands.Contracts
{
    public interface IStopCommandServiceApplication
    {
        Task<ResultApi<StopResponse>> Create(CreateStopRequest stopRequest);
        Task<ResultApi<StopResponse>> Update(UpdateStopRequest stopRequest);
        Task<ResultApi<StopResponse>> Delete(DeleteStopRequest stopRequest);
    }
}
