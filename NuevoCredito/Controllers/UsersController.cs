using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NuevoCreditoAPI.NuevoCredito.Domain.Models;
using NuevoCreditoAPI.NuevoCredito.Domain.Services;
using NuevoCreditoAPI.NuevoCredito.Resources;
using NuevoCreditoAPI.Shared.Extensions;

namespace NuevoCreditoAPI.NuevoCredito.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UsersController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveUserResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var user = _mapper.Map<SaveUserResource, User>(resource);
        var result = await _userService.SaveAsync(user);

        if (!result.Success)
            return BadRequest(result.Message);

        var userResource = _mapper.Map<User, UserResource>(result.Resource);

        return Ok(userResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] UpdateUserResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var user = _mapper.Map<UpdateUserResource, User>(resource); //VERIFICAR SI FUNCIONA
        var result = await _userService.UpdateAsync(id, user);

        if (!result.Success)
            return BadRequest(result.Message);

        var userResource = _mapper.Map<User, UserResource>(result.Resource);

        return Ok(userResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _userService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var userResource = _mapper.Map<User, UserResource>(result.Resource);

        return Ok(userResource);
    }

    [HttpPost("verify-user")]
    public async Task<IActionResult> VerifyUserAsync([FromBody] LoginResource loginResource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var user = await _userService.GetByEmailAndPasswordAsync(loginResource.Email, loginResource.Password);

        if (user == null)
        {
            return NotFound("Jugador no encontrado con las credenciales proporcionadas.");
        }

        var userResource = _mapper.Map<User, UserResource>(user);

        return Ok(userResource);
    }
}