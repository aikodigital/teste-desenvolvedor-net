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
    public class LineQueryServiceApplication : ILineQueryServiceApplication
    {
        protected readonly ILineServices _service;
        protected readonly IMapper _mapper;

        public LineQueryServiceApplication(ILineServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<ResultApi<LineResponse>> FindById(long id)
        {
            Line result = _service.QueryableFor()
                .Where(p => p.Id == id)
                .Include(p => p.Stop)
                .FirstOrDefault();

            return new ResultApi<LineResponse>
            {
                Success = true,
                Data = _mapper.Map<LineResponse>(result)
            };
        }

        public async Task<ResultApi<PagedResult<LineResponse>>> GetAll(FilterPaged filter)
        {
            List<Line> result = await _service.QueryableFor()
                .Include(p => p.Stop)
                .ToListAsync();
            PagedResult<Line> resultModel = await _service.PagedResult(filter.Page, filter.PageSize, result);

            return new ResultApi<PagedResult<LineResponse>>
            {
                Success = true,
                Data = new PagedResult<LineResponse>
                {
                    Page = resultModel.Page,
                    PageSize = resultModel.PageSize,
                    TotalItems = resultModel.TotalItems,
                    
                    Items = _mapper.Map<IList<LineResponse>>(resultModel.Items),
                },
            };
        }

        public async Task<ResultApi<IList<LineResponse>>> LineAndStop(long id)
        {
            List<Line> model = await _service.QueryableFor()
                .Where(p => p.StopId == id)
                .Include(p => p.Stop)
                .ToListAsync();

            return new ResultApi<IList<LineResponse>>
            {
                Success = true,
                Data = _mapper.Map<IList<LineResponse>>(model)
            };
        }
    }
}
