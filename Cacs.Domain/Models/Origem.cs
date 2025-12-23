namespace Cacs.Domain.Models
{
    public class Origem
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; } = string.Empty;
        public string Descricao { get; private set; } = string.Empty;
        public Habilidade Habilidade { get; private set; } = null!;

        public static readonly List<Pericia> Pericias = [];
        private List<string> periciasTreinadas;

        public IReadOnlyCollection<Pericia> PericiasTreinadas { get; private set; } = null!;

        public Origem(string nome, string descricao, IEnumerable<Pericia> periciasTreinadas, Habilidade habilidade)
        {
            if (periciasTreinadas.Count() != 2)
            {
                throw new ArgumentException("A origem deve conceder exatamente 2 pericias.", nameof(periciasTreinadas));
            }

            this.Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            this.Descricao = descricao ?? throw new ArgumentNullException(nameof(descricao));
            this.Habilidade = habilidade;
            this.PericiasTreinadas = periciasTreinadas.ToList().AsReadOnly();
        }

        protected Origem()
        {
        }

        public Origem(string nome, List<string> periciasTreinadas)
        {
            Nome = nome;
            this.periciasTreinadas = periciasTreinadas;
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

        public void DefinirHabilidade(Habilidade habilidade)
        {
            this.Habilidade = habilidade;
        }
    }
}
