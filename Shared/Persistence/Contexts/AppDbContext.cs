using Microsoft.EntityFrameworkCore;
using NuevoCreditoAPI.NuevoCredito.Domain.Models;
using NuevoCreditoAPI.Shared.Extensions;

namespace NuevoCreditoAPI.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<PaymentSchedule> PaymentSchedules { get; set; }
    
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(u=>u.Id);
        builder.Entity<User>().Property(u=>u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(u=>u.Username).IsRequired();
        builder.Entity<User>().Property(u=>u.Email).IsRequired();
        builder.Entity<User>().Property(u=>u.Password).IsRequired();
        
        builder.Entity<PaymentSchedule>().ToTable("PaymentSchedules");
        builder.Entity<PaymentSchedule>().HasKey(p=>p.Id);
        builder.Entity<PaymentSchedule>().Property(p=>p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<PaymentSchedule>().Property(p=>p.Currency).IsRequired();
        builder.Entity<PaymentSchedule>().Property(p=>p.DisbursementDate).IsRequired();
        builder.Entity<PaymentSchedule>().Property(p=>p.PaymentDay).IsRequired();
        builder.Entity<PaymentSchedule>().Property(p=>p.Amount).IsRequired();
        builder.Entity<PaymentSchedule>().Property(p=>p.PropertyValue).IsRequired();
        builder.Entity<PaymentSchedule>().Property(p=>p.TEA).IsRequired();
        builder.Entity<PaymentSchedule>().Property(p=>p.FeesPerYear).IsRequired();
        builder.Entity<PaymentSchedule>().Property(p=>p.GracePeriod).IsRequired();
        builder.Entity<PaymentSchedule>().Property(p=>p.PaymentPeriod).IsRequired();
        builder.Entity<PaymentSchedule>().Property(p=>p.TotalTerm).IsRequired();
        builder.Entity<PaymentSchedule>().Property(p=>p.DesgravamenInsuranceRate).IsRequired();
        builder.Entity<PaymentSchedule>().Property(p=>p.PropertyInsuranceRate).IsRequired();
        builder.Entity<PaymentSchedule>().Property(p=>p.Postage).IsRequired();

        builder.Entity<PaymentSchedule>()
            .HasOne(u=>u.User)
            .WithMany(u=>u.PaymentSchedules)
            .HasForeignKey(u=>u.UserId);
        
        // Apply Snake Case Naming Convention
        builder.UseSnakeCaseNamingConvention();
    }
}