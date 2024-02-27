using Application.Queries.Contracts;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using Domain.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Application.Result;
using SharedKernel.Infrastructure.Pagination;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class VehiclePositionQueryServiceApplication : IVehiclePositionQueryServiceApplication
    {
        protected readonly IVehiclePositionServices _service;
        protected readonly IMapper _mapper;

        public VehiclePositionQueryServiceApplication(IVehiclePositionServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<ResultApi<VehiclePositionResponse>> FindById(long id)
        {
            VehiclePosition model = _service.QueryableFor()
                .Where(p => p.Id == id)
                .FirstOrDefault();

            return new ResultApi<VehiclePositionResponse>
            {
                Success = true,
                Data = _mapper.Map<VehiclePositionResponse>(model)
            };
        }

        public async Task<ResultApi<PagedResult<VehiclePositionResponse>>> GetAll(FilterPaged filter)
        {
            IList<VehiclePosition> resultList = await _service.QueryableFor().ToListAsync();

            PagedResult<VehiclePosition> VehiclePositionModel = await _service.PagedResult(filter.Page, filter.PageSize, resultList);

            return new ResultApi<PagedResult<VehiclePositionResponse>>
            {
                Success = true,
                Data = new PagedResult<VehiclePositionResponse>
                {
                    Page = VehiclePositionModel.Page,
                    PageSize = VehiclePositionModel.PageSize,
                    TotalItems = VehiclePositionModel.TotalItems,
                    Items = _mapper.Map<IList<VehiclePositionResponse>>(VehiclePositionModel.Items),
                },
            };
        }
    }
}
