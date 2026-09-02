using Cacs.Domain.Models.Players;


namespace Cacs.Application.Repositories
{
    public interface IPlayerRepository
    {
        Task<Player?> ObterAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        Task<IReadOnlyList<Player>> ListarAsync(
            CancellationToken cancellationToken = default);

        Task SalvarAsync(
            Player player,
            CancellationToken cancellationToken = default);
    }
}
