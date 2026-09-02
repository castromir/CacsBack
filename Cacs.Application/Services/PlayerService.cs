using Cacs.Application.Dtos;

namespace Cacs.Application.Services
{
    /// <summary>
    ///  Responsável pelos casos de uso relacionados aos jogadores, incluindo a criação, atualização e recuperação de informações dos jogadores.
    /// </summary>
    public class PlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }
        public async Task<PlayerDto?> ObterAsync(Guid id)
        {
            var player = await _repository.ObterAsync(id);

            return player is null
                ? null
                : PlayerMapper.ToDto(player); }
    }
}
