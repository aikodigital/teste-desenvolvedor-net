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
    public class LineCommandServiceApplication : ILineCommandServiceApplication
    {
        protected readonly ILineServices _service;
        protected readonly IMapper _mapper;

        public LineCommandServiceApplication(ILineServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<ResultApi<LineResponse>> Create(CreateLineRequest lineRequest)
        {
            Line model = await _service.Add(_mapper.Map<Line>(lineRequest));
            return new ResultApi<LineResponse>
            {
                Success = true,
                Data = _mapper.Map<LineResponse>(model)
            };
        }

        public async Task<ResultApi<LineResponse>> Delete(DeleteLineRequest lineRequest)
        {
            _service.Delete(_mapper.Map<Line>(lineRequest));
            return new ResultApi<LineResponse>
            {
                Success = true
            };
        }

        public async Task<ResultApi<LineResponse>> Update(UpdateLineRequest lineRequest)
        {
            Line model = Task.FromResult(_service.Update(_mapper.Map<Line>(lineRequest))).Result;
            return new ResultApi<LineResponse>
            {
                Success = true,
                Data = _mapper.Map<LineResponse>(model)
            };
        }
    }
}
