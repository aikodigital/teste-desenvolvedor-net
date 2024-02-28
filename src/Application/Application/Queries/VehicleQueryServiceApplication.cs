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
    public class VehicleQueryServiceApplication : IVehicleQueryServiceApplication
    {
        protected readonly IVehicleServices _service;
        protected readonly IMapper _mapper;

        public VehicleQueryServiceApplication(IVehicleServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<ResultApi<VehicleResponse>> FindById(long id)
        {
            Vehicle result = _service.QueryableFor()
                .Where(p => p.Id == id)
                .Include(p => p.Line)
                .FirstOrDefault();

            return new ResultApi<VehicleResponse>
            {
                Success = true,
                Data = _mapper.Map<VehicleResponse>(result)
            };
        }

        public async Task<ResultApi<PagedResult<VehicleResponse>>> GetAll(FilterPaged filter)
        {
            List<Vehicle> result = await _service.QueryableFor()
                .Include(p => p.VehiclePosition)
                .Include(p => p.Line)
                .ThenInclude(p => p.Stop)
                .ToListAsync();
            PagedResult<Vehicle> vehicleModel = await _service.PagedResult(filter.Page, filter.PageSize, result);

            return new ResultApi<PagedResult<VehicleResponse>>
            {
                Success = true,
                Data = new PagedResult<VehicleResponse>
                {
                    Page = vehicleModel.Page,
                    PageSize = vehicleModel.PageSize,
                    TotalItems = vehicleModel.TotalItems,
                    Items = _mapper.Map<IList<VehicleResponse>>(vehicleModel.Items),
                },
            };
        }

        public async Task<ResultApi<IList<VehicleResponse>>> GetVehiclePosition(long id)
        {
            List<Vehicle> model = await _service.QueryableFor()
                .Where(p => p.Id == id)
                .Include(p => p.VehiclePosition)
                .Include(p => p.Line)
                .ThenInclude(p => p.Stop)
                .ToListAsync();

            return new ResultApi<IList<VehicleResponse>>
            {
                Success = true,
                Data = _mapper.Map<IList<VehicleResponse>>(model)
            };
        }

        public async Task<ResultApi<IList<VehicleResponse>>> VehiclesAndLines(long id)
        {
            List<Vehicle> model = await _service.QueryableFor()
                .Where(p => p.LineId == id)
                .ToListAsync();

            return new ResultApi<IList<VehicleResponse>>
            {
                Success = true,
                Data = _mapper.Map<IList<VehicleResponse>>(model)
            };
        }
    }
}
