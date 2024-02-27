using Application.Responses;
using SharedKernel.Application.Result;
using SharedKernel.Infrastructure.Pagination;
using System.Threading.Tasks;

namespace Application.Queries.Contracts
{
    public interface IVehiclePositionQueryServiceApplication
    {
        Task<ResultApi<PagedResult<VehiclePositionResponse>>> GetAll(FilterPaged filter);
        Task<ResultApi<VehiclePositionResponse>> FindById(long id);
    }
}
