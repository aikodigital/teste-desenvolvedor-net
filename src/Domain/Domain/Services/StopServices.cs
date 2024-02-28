using Domain.Entities;
using Domain.IRepository;
using Domain.Services.Contracts;
using SharedKernel.Application.Services;
using SharedKernel.Infrastructure.UnitOfWork;

namespace Domain.Services
{
    public class StopServices : Service<Stop, IStopRepository>, IStopServices
    {
        public StopServices(IStopRepository repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork) { }
    }
}
