using NuevoCreditoAPI.NuevoCredito.Domain.Repositories;
using NuevoCreditoAPI.Shared.Persistence.Contexts;

namespace NuevoCreditoAPI.Shared.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}