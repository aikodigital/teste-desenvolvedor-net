using AikoApi.Infra.Context;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AikoApi.Controllers
{
    public class BaseController : ControllerBase
	{
		protected readonly Context _context;
		protected readonly IMapper _mapper;

		public BaseController(Context context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}
	}
}
