using AutoMapper;
using Domain.Entities;
using Domain.IRepository;
using SharedKernel.Infrastructure.DataContext;

namespace Data.Repository
{
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(IDataContext context, IMapper mapper) : base(context, mapper) { }
    }
}
