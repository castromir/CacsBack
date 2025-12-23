namespace Cacs.Domain.Models
{
    using Cacs.Domain.Models.Classe;
    using Cacs.Domain.Models.Enums;
    using Cacs.Domain.Models.Itens;

    /// <summary>
    /// Representa a ficha de um personagem, contendo atributos,
    /// pericias, habilidades, rituais e outras informacoes relevantes.
    /// </summary>
    public class Ficha
    {
        public int Id { get; private set; }
        public int NEX { get; private set; }

        public int PV { get; private set; }
        public int PE { get; private set; }
        public int SAN { get; private set; }

        public int Defesa { get; private set; }
        public int Bloqueio { get; private set; }
        public int Esquiva { get; private set; }

        public int Nivel => (int)Math.Ceiling(this.NEX / 5.0);

        public string NomePersonagem { get; private set; } = string.Empty;
        public string NomeJogador { get; private set; } = string.Empty;
        public string Deslocamento { get; private set; } = string.Empty;

        public Origem Origem { get; private set; } = null!;
        public List<Habilidade> Habilidades { get; private set; } = [];
        public List<Item> Itens { get; private set; } = [];
        public List<Ritual> Rituais { get; private set; } = [];

        public ClasseBase Classe { get; private set; }

        private readonly List<Pericia> pericias = [];
        private readonly List<Atributo> atributos = [];
        public IReadOnlyCollection<Pericia> Pericias => this.pericias.AsReadOnly();
        public IReadOnlyCollection<Atributo> Atributos => this.atributos.AsReadOnly();

        public Ficha(
            string nomePersonagem,
            int nex,
            ClasseBase classe,
            Origem origem
            )
        {
            this.NomePersonagem = nomePersonagem;
            this.NEX = nex;
            this.Classe = classe;

            foreach (NomePericia nome in Enum.GetValues(typeof(NomePericia)))
            {
                this.pericias.Add(new Pericia(nome));
            }

            foreach (var pericia in origem.PericiasTreinadas)
            {
                this.AtualizarPericiaTreinamento(pericia.NomePericia, pericia.NivelTreinamento.Nivel);
            }
        }

        protected Ficha()
        {
        }

        public Atributo ObterAtributo(NomeAtributo nome) =>
            this.atributos.First(p => p.NomeAtributo == nome);

        public Habilidade ObterHabilidade(string nome) =>
            this.Habilidades.FirstOrDefault(r => r.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase))
                ?? throw new InvalidOperationException($"Habilidade '{nome}' nao encontrada.");

        public Habilidade ObterOrigemHabilidade() => this.Origem.Habilidade;

        public IReadOnlyCollection<Pericia> ObterOrigemPericias() => this.Origem.PericiasTreinadas;

        public Pericia ObterPericia(NomePericia nome) =>
            this.pericias.First(p => p.NomePericia == nome);

        public Ritual ObterRitual(string nome) =>
            this.Rituais.FirstOrDefault(r => r.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase))
                ?? throw new InvalidOperationException($"Ritual '{nome}' nao encontrado.");

        public void AtualizarAtributo(NomeAtributo nome, int valor) =>
            this.ObterAtributo(nome).DefinirAtributo(valor);

        public void AtualizarNomePersonagem(string nome) => this.NomePersonagem = nome;

        public void AtualizarHabilidadeDescricao(string nome, string descricao) =>
            this.ObterHabilidade(nome).DefinirDescricao(descricao);

        public void AtualizarHabilidadeNome(string nomeAntigo, string novoNome) =>
            this.ObterHabilidade(nomeAntigo).DefinirNome(novoNome);

        public void AtualizarPericiaOutrosBonus(NomePericia nome, int bonus)
        {
            var pericia = this.ObterPericia(nome);
            pericia.DefinirOutrosBonus(bonus);
        }

        public void AtualizarPericiaTreinamento(NomePericia nome, Treinamento nivel)
        {
            var pericia = this.pericias.FirstOrDefault(p => p.NomePericia == nome)
                ?? throw new InvalidOperationException($"Pericia '{nome}' nao encontrada.");
            pericia.DefinirNivel(nivel);
        }

        public void AtualizarRitualCustoPE(string nome, int custoPE) =>
            this.ObterRitual(nome).DefinirCustoPE(custoPE);

        public void AtualizarRitualElemento(string nome, Elemento elemento) =>
            this.ObterRitual(nome).DefinirElemento(elemento);

        public void AtualizarRitualNome(string nomeAntigo, string novoNome) =>
            this.ObterRitual(nomeAntigo).DefinirNome(novoNome);

        public void AtualizarRitualCirculo(string nome, int circulo) =>
            this.ObterRitual(nome).DefinirCirculo(circulo);

        public void AtualizarRitualDescricaoBase(string nome, string descricao) =>
            this.ObterRitual(nome).DefinirDescricaoBase(descricao);

        public void AtualizarRitualExecucao(string nome, string execucao) =>
            this.ObterRitual(nome).DefinirExecucao(execucao);

        public void AtualizarRitualAlcance(string nome, string alcance) =>
            this.ObterRitual(nome).DefinirAlcance(alcance);

        public void AtualizarRitualDuracao(string nome, string duracao) =>
            this.ObterRitual(nome).DefinirDuracao(duracao);

        public void AtualizarRitualResitencia(string nome, string resistencia) =>
            this.ObterRitual(nome).DefinirResistencia(resistencia);

        public int CalcularPericiaBonus(NomePericia nomePericia)
        {
            var pericia = this.Pericias.FirstOrDefault(p => p.NomePericia == nomePericia)
                ?? throw new InvalidOperationException($"Pericia '{nomePericia}' nao encontrada.");

            return pericia.NivelTreinamento.ObterBonus()
                + pericia.OutrosBonus
                + this.Nivel;
        }
    }
}
