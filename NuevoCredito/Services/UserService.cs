using NuevoCreditoAPI.NuevoCredito.Domain.Models;
using NuevoCreditoAPI.NuevoCredito.Domain.Repositories;
using NuevoCreditoAPI.NuevoCredito.Domain.Services;
using NuevoCreditoAPI.NuevoCredito.Domain.Services.Communication;

namespace NuevoCreditoAPI.NuevoCredito.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<UserResponse> SaveAsync(User user)
    {
        try
        {
            // Verificar si el correo electrónico ya existe en la base de datos
            var existingUser = await _userRepository.FindByEmailAsync(user.Email);
            
            if (existingUser != null)
                return new UserResponse("There's already a user with that email.");
            
            await _userRepository.AddAsync(user);
            await _unitOfWork.CompleteAsync();
            return new UserResponse(user);
        }
        catch (Exception e)
        {
            return new UserResponse($"An error occurred while saving the user: {e.Message}");
        }
    }

    public async Task<UserResponse> UpdateAsync(int id, User user)
    {
        var existingUser = await _userRepository.FindByIdAsync(id);

        if (existingUser == null)
            return new UserResponse("User not found. It may not exist.");

        existingUser.Username = user.Username;
        existingUser.Password = user.Password;
        
        try
        {
            _userRepository.Update(existingUser);
            await _unitOfWork.CompleteAsync();
            return new UserResponse(existingUser);
        }
        catch (Exception e)
        {
            return new UserResponse($"An error occurred while updating the user: {e.Message}");
        }
    }

    public async Task<UserResponse> DeleteAsync(int id)
    {
        var existingUser = await _userRepository.FindByIdAsync(id);
        
        if (existingUser == null)
            return new UserResponse("User not found. It may not exist.");
        
        try
        {
            _userRepository.Remove(existingUser);
            await _unitOfWork.CompleteAsync();
            return new UserResponse(existingUser);
        }
        catch (Exception e)
        {
            return new UserResponse($"An error occurred while deleting the user: {e.Message}");
        }
    }

    public async Task<User> GetByEmailAndPasswordAsync(string email, string password)
    {
        return await _userRepository.FindByEmailAndPasswordAsync(email, password);
    }
}