namespace NuevoCreditoAPI.NuevoCredito.Resources;

public class UpdatePaymentScheduleResource
{
    public string Currency { get; set; }
    public string DisbursementDate { get; set; }
    public string PaymentDay { get; set; }
    public string Amount { get; set; }
    public string PropertyValue { get; set; }
    public string TEA { get; set; }
    public string FeesPerYear { get; set; }
    public string GracePeriod { get; set; }
    public string PaymentPeriod { get; set; }
    public string TotalTerm { get; set; }
    public string DesgravamenInsuranceRate { get; set; }
    public string PropertyInsuranceRate { get; set; }
    public string Postage { get; set; }
}