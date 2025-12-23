namespace Cacs.Application.Services;

using Cacs.Domain.Models;

public interface IFichaService
{
    Task<Ficha?> ObterPorIdAsync(Guid id);
}
