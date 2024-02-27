using Application.Commands.Contracts;
using Application.Requests;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using Domain.Services.Contracts;
using SharedKernel.Application.Result;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class StopCommandServiceApplication : IStopCommandServiceApplication
    {
        protected readonly IStopServices _service;
        protected readonly IMapper _mapper;

        public StopCommandServiceApplication(IStopServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<ResultApi<StopResponse>> Create(CreateStopRequest stopRequest)
        {
            Stop model = await _service.Add(_mapper.Map<Stop>(stopRequest));
            return new ResultApi<StopResponse>
            {
                Success = true,
                Data = _mapper.Map<StopResponse>(model)
            };
        }

        public async Task<ResultApi<StopResponse>> Update(UpdateStopRequest stopRequest)
        {
            Stop model = _service.Update(_mapper.Map<Stop>(stopRequest));
            return new ResultApi<StopResponse>
            {
                Success = true,
                Data = _mapper.Map<StopResponse>(model)
            };
        }

        public async Task<ResultApi<StopResponse>> Delete(DeleteStopRequest stopRequest)
        {
            _service.Delete(_mapper.Map<Stop>(stopRequest));
            return new ResultApi<StopResponse>
            {
                Success = true
            };
        }
    }
}
