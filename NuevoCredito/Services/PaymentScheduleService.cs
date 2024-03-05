using NuevoCreditoAPI.NuevoCredito.Domain.Models;
using NuevoCreditoAPI.NuevoCredito.Domain.Repositories;
using NuevoCreditoAPI.NuevoCredito.Domain.Services;
using NuevoCreditoAPI.NuevoCredito.Domain.Services.Communication;

namespace NuevoCreditoAPI.NuevoCredito.Services;

public class PaymentScheduleService : IPaymentScheduleService
{
    private readonly IPaymentScheduleRepository _paymentScheduleRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PaymentScheduleService(IPaymentScheduleRepository paymentScheduleRepository, IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _paymentScheduleRepository = paymentScheduleRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<PaymentSchedule>> ListByUserIdAsync(int userId)
    {
        return await _paymentScheduleRepository.FindByUserIdAsync(userId);
    }

    public async Task<PaymentScheduleResponse> SaveAsync(PaymentSchedule paymentSchedule)
    {
        var existingUser = await _userRepository.FindByIdAsync(paymentSchedule.UserId);
        
        if (existingUser == null)
            return new PaymentScheduleResponse("User not found. It may not exist.");
        
        try
        {
            await _paymentScheduleRepository.AddAsync(paymentSchedule);
            await _unitOfWork.CompleteAsync();
            return new PaymentScheduleResponse(paymentSchedule);
        }
        catch (Exception e)
        {
            return new PaymentScheduleResponse($"An error occurred when saving the payment schedule: {e.Message}");
        }
    }

    public async Task<PaymentScheduleResponse> UpdateAsync(int paymentScheduleId, PaymentSchedule paymentSchedule)
    {
        var existingPaymentSchedule = await _paymentScheduleRepository.FindByIdAsync(paymentScheduleId);

        if (existingPaymentSchedule == null)
            return new PaymentScheduleResponse("Payment schedule not found.");
        
        existingPaymentSchedule.Currency = paymentSchedule.Currency;
        existingPaymentSchedule.DisbursementDate = paymentSchedule.DisbursementDate;
        existingPaymentSchedule.PaymentDay = paymentSchedule.PaymentDay;
        existingPaymentSchedule.Amount = paymentSchedule.Amount;
        existingPaymentSchedule.PropertyValue = paymentSchedule.PropertyValue;
        existingPaymentSchedule.TEA = paymentSchedule.TEA;
        existingPaymentSchedule.FeesPerYear = paymentSchedule.FeesPerYear;
        existingPaymentSchedule.GracePeriod = paymentSchedule.GracePeriod;
        existingPaymentSchedule.PaymentPeriod = paymentSchedule.PaymentPeriod;
        existingPaymentSchedule.TotalTerm = paymentSchedule.TotalTerm;
        existingPaymentSchedule.DesgravamenInsuranceRate = paymentSchedule.DesgravamenInsuranceRate;
        existingPaymentSchedule.PropertyInsuranceRate = paymentSchedule.PropertyInsuranceRate;
        existingPaymentSchedule.Postage = paymentSchedule.Postage;
        
        try
        {
            _paymentScheduleRepository.Update(existingPaymentSchedule);
            await _unitOfWork.CompleteAsync();
            return new PaymentScheduleResponse(existingPaymentSchedule);
        }
        catch (Exception e)
        {
            return new PaymentScheduleResponse($"An error occurred when updating the payment schedule: {e.Message}");
        }
    }

    public async Task<PaymentScheduleResponse> DeleteAsync(int paymentScheduleId)
    {
        var existingPaymentSchedule = await _paymentScheduleRepository.FindByIdAsync(paymentScheduleId);
        
        if (existingPaymentSchedule == null)
            return new PaymentScheduleResponse("Payment schedule not found. It may not exist.");
        
        try
        {
            _paymentScheduleRepository.Remove(existingPaymentSchedule);
            await _unitOfWork.CompleteAsync();
            return new PaymentScheduleResponse(existingPaymentSchedule);
        }
        catch (Exception e)
        {
            return new PaymentScheduleResponse($"An error occurred when deleting the payment schedule: {e.Message}");
        }
    }
}