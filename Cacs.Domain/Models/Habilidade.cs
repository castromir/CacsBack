namespace Cacs.Domain.Models
{
    using Cacs.Domain.Models.Classe;
    using Cacs.Domain.Models.Enums;

    public class Habilidade
    {
        public Guid Id { get; private set; }

        public string Nome { get; private set; } = string.Empty;
        public string Descricao { get; private set; } = string.Empty;
        public FonteHabilidade Fonte { get; private set; }

        public ClasseBase? ClasseRequerida { get; private set; }
        public Trilha? TrilhaRequerida { get; private set; }
        public Origem? OrigemRequerida { get; private set; }
        public PoderParanormal? PoderParanormalRequerido { get; private set; }

        public Guid? ClasseRequeridaId { get; private set; }
        public Guid? TrilhaRequeridaId { get; private set; }
        public Guid? OrigemRequeridaId { get; private set; }
        public Guid? PoderParanormalRequeridoId { get; private set; }

        public Habilidade(
            string nome,
            string descricao,
            FonteHabilidade fonte,
            ClasseBase? classeRequerida = null,
            Trilha? trilhaRequerida = null,
            Origem? origemRequerida = null,
            PoderParanormal? poderParanormalRequerido = null)
        {
            this.Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            this.Descricao = descricao ?? throw new ArgumentNullException(nameof(descricao));
            this.Fonte = fonte;

            this.ClasseRequerida = classeRequerida;
            this.TrilhaRequerida = trilhaRequerida;
            this.OrigemRequerida = origemRequerida;
            this.PoderParanormalRequerido = poderParanormalRequerido;

            this.ClasseRequeridaId = classeRequerida?.Id;
            this.TrilhaRequeridaId = trilhaRequerida?.Id;
            this.OrigemRequeridaId = origemRequerida?.Id;
            this.PoderParanormalRequeridoId = poderParanormalRequerido?.Id;
        }

        protected Habilidade()
        {
        }

        public void DefinirNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new ArgumentException("O nome não pode ser vazio.", nameof(nome));
            }

            this.Nome = nome;
        }

        public void DefinirDescricao(string descricao)
        {
            if (string.IsNullOrWhiteSpace(descricao))
            {
                throw new ArgumentException("A descrição não pode ser vazia.", nameof(descricao));
            }

            this.Descricao = descricao;
        }

        public void DefinirFonte(FonteHabilidade fonte)
        {
            this.Fonte = fonte;
        }

        public void DefinirClasseRequerida(ClasseBase classe)
        {
            this.ClasseRequerida = classe;
        }

        public void DefinirTrilhaRequerida(Trilha trilha)
        {
            this.TrilhaRequerida = trilha;
        }

        public void DefinirOrigemRequerida(Origem origem)
        {
            this.OrigemRequerida = origem;
        }

        public void DefinirPoderParanormalRequerido(PoderParanormal poderParanormal)
        {
            this.PoderParanormalRequerido = poderParanormal;
        }
    }
}
