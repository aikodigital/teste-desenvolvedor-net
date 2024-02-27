using AutoMapper;
using Domain.Entities;
using Domain.IRepository;
using SharedKernel.Infrastructure.DataContext;

namespace Data.Repository
{
    public class StopRepository : Repository<Stop>, IStopRepository
    {
        public StopRepository(IDataContext context, IMapper mapper) : base(context, mapper) { }
    }
}
