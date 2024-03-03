using Microsoft.EntityFrameworkCore;
using NuevoCreditoAPI.NuevoCredito.Domain.Models;
using NuevoCreditoAPI.NuevoCredito.Domain.Repositories;
using NuevoCreditoAPI.Shared.Persistence.Contexts;
using NuevoCreditoAPI.Shared.Persistence.Repositories;

namespace NuevoCreditoAPI.NuevoCredito.Persistence.Repositories;

public class PaymentScheduleRespository : BaseRepository, IPaymentScheduleRespository
{
    public PaymentScheduleRespository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<PaymentSchedule>> ListAsync() //POSIBLE FALLO POR EL INCLUDE
    {
        return await _context.PaymentSchedules.Include(p => p.User).ToListAsync();
    }

    public async Task AddAsync(PaymentSchedule paymentSchedule)
    {
        await _context.PaymentSchedules.AddAsync(paymentSchedule);
    }

    public async Task<PaymentSchedule> FindByIdAsync(int paymentScheduleId)
    {
        return await _context.PaymentSchedules.Include(p => p.User).FirstOrDefaultAsync(p => p.Id == paymentScheduleId);
    }

    public async Task<PaymentSchedule> FindByTitleAsync(string title)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<PaymentSchedule>> FindByUserIdAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public void Update(PaymentSchedule paymentSchedule)
    {
        throw new NotImplementedException();
    }

    public void Remove(PaymentSchedule paymentSchedule)
    {
        throw new NotImplementedException();
    }
}