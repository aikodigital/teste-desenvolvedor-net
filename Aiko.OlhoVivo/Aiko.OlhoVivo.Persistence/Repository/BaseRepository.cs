using Aiko.OlhoVivo.Domain.Interfaces.Repository;
using Aiko.OlhoVivo.Persistence.Context;

namespace Aiko.OlhoVivo.Persistence.Repository;

public class BaseRepository<T> : IRepositorioBase<T> where T : class
{
    private readonly AikoOlhoVivoContext _context;

    public BaseRepository(AikoOlhoVivoContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAsync(T item)
    {
        await _context.AddAsync(item);
        return 0 < await _context.SaveChangesAsync();
 
    }

    public async Task<bool> UpdateAsync(T item)
    {
        _context.Update(item);
        return 0 < await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(T item)
    {
        _context.Remove(item);
        return 0 < await _context.SaveChangesAsync();
    }
}