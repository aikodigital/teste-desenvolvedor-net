using AutoMapper;
using Domain.Entities;
using Domain.IRepository;
using SharedKernel.Infrastructure.DataContext;

namespace Data.Repository
{
    public class VehiclePositionRepository : Repository<VehiclePosition>, IVehiclePositionRepository
    {
        public VehiclePositionRepository(IDataContext context, IMapper mapper) : base(context, mapper) { }
    }
}
