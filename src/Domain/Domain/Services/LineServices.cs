using Domain.Entities;
using Domain.IRepository;
using Domain.Services.Contracts;
using SharedKernel.Application.Services;
using SharedKernel.Infrastructure.UnitOfWork;

namespace Domain.Services
{
    public class LineServices : Service<Line, ILineRepository>, ILineServices
    {
        public LineServices(ILineRepository repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {

        }
    }
}
