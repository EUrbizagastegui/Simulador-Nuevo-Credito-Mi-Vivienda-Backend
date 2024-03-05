using System.Text.Json.Serialization;

namespace NuevoCreditoAPI.NuevoCredito.Domain.Models;

public class PaymentSchedule
{
    public int Id { get; set; }
    public string Currency { get; set; }
    public string DisbursementDate { get; set; }
    public string PaymentDay { get; set; }
    public int Amount { get; set; }
    public int PropertyValue { get; set; }
    public double TEA { get; set; }
    public int FeesPerYear { get; set; }
    public int GracePeriod { get; set; }
    public int PaymentPeriod { get; set; }
    public int TotalTerm { get; set; }
    public double DesgravamenInsuranceRate { get; set; }
    public double PropertyInsuranceRate { get; set; }
    public double Postage { get; set; }
    
    public int UserId { get; set; }

    public User User { get; set; }
}