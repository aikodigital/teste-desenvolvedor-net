using Application.Requests;
using Application.Responses;
using SharedKernel.Application.Result;
using SharedKernel.Infrastructure.Pagination;
using System.Threading.Tasks;

namespace Application.Queries.Contracts
{
    public interface IStopQueryServiceApplication
    {
        Task<ResultApi<PagedResult<StopResponse>>> GetAll(FilterPaged filter);
        Task<ResultApi<StopResponse>> FindById(long id);
    }
}
