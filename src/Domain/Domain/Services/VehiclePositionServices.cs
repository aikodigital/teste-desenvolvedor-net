using Domain.Entities;
using Domain.IRepository;
using Domain.Services.Contracts;
using SharedKernel.Application.Services;
using SharedKernel.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class VehiclePositionServices : Service<VehiclePosition, IVehiclePositionRepository>, IVehiclePositionServices
    {
        public VehiclePositionServices(IVehiclePositionRepository repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork) { }
    }
}
