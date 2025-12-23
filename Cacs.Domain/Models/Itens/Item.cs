namespace Cacs.Domain.Models.Itens
{
    using Cacs.Domain.Models.Enums;

    public abstract class Item
    {
        protected Guid Id { get; private set; }
        public string Nome { get; protected set; } = string.Empty;
        public string Descricao { get; protected set; } = string.Empty;
        protected int Espaco { get; private set; }
        protected int Categoria { get; private set; }
        protected Proficiencia? Proficiencia { get; private set; }

        protected Item(
           string nome,
           string descricao,
           int espaco,
           int categoria,
           Proficiencia? proficiencia)
        {
            this.Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            this.Descricao = descricao ?? throw new ArgumentNullException(nameof(descricao));
            this.Espaco = espaco;
            this.Categoria = categoria;
            this.Proficiencia = proficiencia;
        }
    }
}
