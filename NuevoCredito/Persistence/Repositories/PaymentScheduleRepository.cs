using Microsoft.EntityFrameworkCore;
using NuevoCreditoAPI.NuevoCredito.Domain.Models;
using NuevoCreditoAPI.NuevoCredito.Domain.Repositories;
using NuevoCreditoAPI.Shared.Persistence.Contexts;
using NuevoCreditoAPI.Shared.Persistence.Repositories;

namespace NuevoCreditoAPI.NuevoCredito.Persistence.Repositories;

public class PaymentScheduleRepository : BaseRepository, IPaymentScheduleRepository
{
    public PaymentScheduleRepository(AppDbContext context) : base(context)
    {
    }

    public async Task AddAsync(PaymentSchedule paymentSchedule)
    {
        await _context.PaymentSchedules.AddAsync(paymentSchedule);
    }

    public void Update(PaymentSchedule paymentSchedule)
    {
        _context.PaymentSchedules.Update(paymentSchedule);
    }

    public void Remove(PaymentSchedule paymentSchedule)
    {
        _context.PaymentSchedules.Remove(paymentSchedule);
    }

    public async Task<IEnumerable<PaymentSchedule>> FindByUserIdAsync(int userId)
    {
        return await _context
            .PaymentSchedules
            .Where(p => p.UserId == userId)
            .Include(p => p.User)
            .ToListAsync();
    }

    public async Task<PaymentSchedule> FindByIdAsync(int paymentScheduleId)
    {
        return await _context.PaymentSchedules.FindAsync(paymentScheduleId);
    }
}