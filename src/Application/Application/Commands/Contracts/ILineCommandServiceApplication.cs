using Application.Requests;
using Application.Responses;
using SharedKernel.Application.Result;
using System.Threading.Tasks;

namespace Application.Commands.Contracts
{
    public interface ILineCommandServiceApplication
    {
        Task<ResultApi<LineResponse>> Create(CreateLineRequest lineRequest);
        Task<ResultApi<LineResponse>> Update(UpdateLineRequest lineRequest);
        Task<ResultApi<LineResponse>> Delete(DeleteLineRequest lineRequest);
    }
}
