namespace Cacs.Domain.Models.Players
{
    public sealed class Categoria
    {
        public CategoriaNivel Nivel { get; }

        public int Quantidade { get; private set; }

        public int Pontos => (int)Nivel * Quantidade;

        public Categoria(CategoriaNivel nivel, int quantidade)
        {
            Nivel = nivel;
            Quantidade = quantidade;
        }
    }
}
