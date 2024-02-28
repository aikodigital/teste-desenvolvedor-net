using Application.Responses;
using SharedKernel.Application.Result;
using SharedKernel.Infrastructure.Pagination;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Queries.Contracts
{
    public interface IVehicleQueryServiceApplication
    {
        Task<ResultApi<PagedResult<VehicleResponse>>> GetAll(FilterPaged filter);
        Task<ResultApi<IList<VehicleResponse>>> GetVehiclePosition(long id);
        Task<ResultApi<IList<VehicleResponse>>> VehiclesAndLines(long id);
        Task<ResultApi<VehicleResponse>> FindById(long id);
    }
}
