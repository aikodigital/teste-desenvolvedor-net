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
    public class StopQueryServiceApplication : IStopQueryServiceApplication
    {
        protected readonly IStopServices _service;
        protected readonly IMapper _mapper ;

        public StopQueryServiceApplication(IStopServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<ResultApi<StopResponse>> FindById(long id)
        {
            Stop result = _service.QueryableFor()
                .Where(p => p.Id == id)
                .FirstOrDefault();

            return new ResultApi<StopResponse>
            {
                Success = true,
                Data = _mapper.Map<StopResponse>(result)
            };
        }

        public async Task<ResultApi<PagedResult<StopResponse>>> GetAll(FilterPaged filter)
        {
            List<Stop> result = await _service.QueryableFor().ToListAsync();
            PagedResult<Stop> stopModel = await _service.PagedResult(filter.Page, filter.PageSize, result) ;

            return new ResultApi<PagedResult<StopResponse>>
            {
                Success = true,
                Data = new PagedResult<StopResponse>
                {
                    Page = stopModel.Page,
                    PageSize = stopModel.PageSize,
                    TotalItems = stopModel.TotalItems,
                    Items = _mapper.Map<IList<StopResponse>>(stopModel.Items),
                },
            };
        }
    }
}
