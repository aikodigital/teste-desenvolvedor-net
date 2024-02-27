using Domain.Entities;
using Domain.IRepository;
using Domain.Services.Contracts;
using SharedKernel.Application.Services;
using SharedKernel.Infrastructure.UnitOfWork;

namespace Domain.Services
{
    public class VehicleServices : Service<Vehicle, IVehicleRepository>, IVehicleServices
    {
        public VehicleServices(IVehicleRepository repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork) { }
    }
}
