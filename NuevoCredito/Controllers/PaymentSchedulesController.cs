using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NuevoCreditoAPI.NuevoCredito.Domain.Models;
using NuevoCreditoAPI.NuevoCredito.Domain.Services;
using NuevoCreditoAPI.NuevoCredito.Resources;
using NuevoCreditoAPI.Shared.Extensions;

namespace NuevoCreditoAPI.NuevoCredito.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class PaymentSchedulesController : ControllerBase
{
    private readonly IPaymentScheduleService _paymentScheduleService;
    private readonly IMapper _mapper;

    public PaymentSchedulesController(IPaymentScheduleService paymentScheduleService, IMapper mapper)
    {
        _paymentScheduleService = paymentScheduleService;
        _mapper = mapper;
    }

    [HttpGet("{userId}/payment-schedules")]
    public async Task<IActionResult> GetAllByUserIdAsync(int userId)
    {
        var paymentSchedules = await _paymentScheduleService.ListByUserIdAsync(userId);

        if (paymentSchedules.Count() == 0)
            return NotFound($"No existing payment schedules for user {userId}");

        var paymentScheduleResource = _mapper.Map<IEnumerable<PaymentSchedule>, IEnumerable<PaymentScheduleResource>>(paymentSchedules);

        return Ok(paymentScheduleResource);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SavePaymentScheduleResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var paymentSchedule = _mapper.Map<SavePaymentScheduleResource, PaymentSchedule>(resource);
        var result = await _paymentScheduleService.SaveAsync(paymentSchedule);

        if (!result.Success)
            return BadRequest(result.Message);

        var paymentScheduleResource = _mapper.Map<PaymentSchedule, PaymentScheduleResource>(result.Resource);

        return Ok(paymentScheduleResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] UpdatePaymentScheduleResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var paymentSchedule = _mapper.Map<UpdatePaymentScheduleResource, PaymentSchedule>(resource);
        var result = await _paymentScheduleService.UpdateAsync(id, paymentSchedule);

        if (!result.Success)
            return BadRequest(result.Message);

        var paymentScheduleResource = _mapper.Map<PaymentSchedule, PaymentScheduleResource>(result.Resource);

        return Ok(paymentScheduleResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _paymentScheduleService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var paymentScheduleResource = _mapper.Map<PaymentSchedule, PaymentScheduleResource>(result.Resource);

        return Ok(paymentScheduleResource);
    }
}