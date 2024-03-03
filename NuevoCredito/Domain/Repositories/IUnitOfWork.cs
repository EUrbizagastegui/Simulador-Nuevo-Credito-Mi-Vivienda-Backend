namespace NuevoCreditoAPI.NuevoCredito.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}