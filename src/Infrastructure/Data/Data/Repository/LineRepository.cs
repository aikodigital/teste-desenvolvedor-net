using AutoMapper;
using Domain.Entities;
using Domain.IRepository;
using SharedKernel.Infrastructure.DataContext;

namespace Data.Repository
{
    public class LineRepository : Repository<Line>, ILineRepository
    {
        public LineRepository(IDataContext context, IMapper mapper) : base(context, mapper) { }
    }
}
