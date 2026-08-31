using Cacs.Domain.Models.SeedWork;

namespace Cacs.Domain.Models.Players
{
    public class Player : Entidade, IAggregateRoot
    {
        private readonly List<Categoria> _categorias = [];

        public IReadOnlyCollection<Categoria> Categorias => _categorias;

        private int CalcularPontos()
        {
            var pontos = 0;
            foreach (var categoria in _categorias)
            {
                pontos += categoria.Pontos;
            }

            return pontos;
        }

        public void MudarCategoria(CategoriaNivel nivel, int novaQuantidade)
        {
            var valor = (int)nivel * novaQuantidade;
            var pontos = CalcularPontos();

            if (pontos + valor > 16)
            {
                throw new InvalidOperationException(
                    "O jogador não pode ultrapassar 16 pontos.");
            }

            if (valor < 0)
            {
                throw new InvalidOperationException(
                    "O jogador não pode ter quantidade negativa.");
            }
        }
    }
}
