using Application.Responses;
using SharedKernel.Application.Result;
using SharedKernel.Infrastructure.Pagination;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Queries.Contracts
{
    public interface ILineQueryServiceApplication
    {
        Task<ResultApi<PagedResult<LineResponse>>> GetAll(FilterPaged filter);
        Task<ResultApi<LineResponse>> FindById(long id);
        Task<ResultApi<IList<LineResponse>>> LineAndStop(long id);
    }
}
