namespace Cacs.Domain.Models.Players
{
    public sealed class Categoria
    {
        public CategoriaNivel Nivel { get; }

        public int Quantidade { get; private set; }

        public int Pontos => (int)Nivel * Quantidade;

        public Categoria(CategoriaNivel nivel, int quantidade)
        {
            if (quantidade < 0)
            {
                throw new InvalidOperationException(
                    "A quantidade não pode ser negativa.");
            }

            Nivel = nivel;
            Quantidade = quantidade;
        }

        public void AlterarQuantidade(int novaQuantidade)
        {
            if (novaQuantidade < 0)
            {
                throw new InvalidOperationException(
                    "A quantidade não pode ser negativa.");
            }

            Quantidade = novaQuantidade;
        }
    }
}
