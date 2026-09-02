using Cacs.Domain.Models.SeedWork;

namespace Cacs.Domain.Models.Players
{
    public class Player : Entidade, IAggregateRoot
    {
        private const int MaxPontos = 16;

        private readonly List<Categoria> _categorias = [];

        public IReadOnlyCollection<Categoria> Categorias => _categorias;

        public int Pontos => _categorias.Sum(c => c.Pontos);

        public string Nome { get; private set; } = string.Empty;

        private Player(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new ArgumentException(
                    "O nome do jogador não pode ser vazio.",
                    nameof(nome));
            }
            Nome = nome;
        }

        public static Player Criar(string nome)
        {
            var player = new Player(nome);

            player._categorias.Add(new Categoria(CategoriaNivel.I, 0));
            player._categorias.Add(new Categoria(CategoriaNivel.II, 0));
            player._categorias.Add(new Categoria(CategoriaNivel.III, 0));
            player._categorias.Add(new Categoria(CategoriaNivel.IV, 0));

            return player;
        }

        public void MudarCategoria(
            CategoriaNivel nivel,
            int novaQuantidade)
        {
            var categoria = _categorias.FirstOrDefault(
                c => c.Nivel == nivel);

            if (categoria is null)
            {
                throw new InvalidOperationException(
                    "Categoria não encontrada.");
            }

            var pontosSemCategoria = Pontos - categoria.Pontos;
            var novosPontos = (int)nivel * novaQuantidade;

            if (pontosSemCategoria + novosPontos > MaxPontos)
            {
                throw new InvalidOperationException(
                    "O jogador não pode ultrapassar 16 pontos.");
            }

            categoria.AlterarQuantidade(novaQuantidade);
        }
    }
}

/*
 * 1. Qual é a responsabilidade da classe?

Antes de escrever C#, responda:

"O que essa classe faz?"

Exemplos:

Player       → representa um jogador e suas regras
PlayerService → executa casos de uso relacionados a Player
PlayerRepository → acessa/persiste Players
PlayerDto    → transporta dados

Isso já ajuda a decidir o que entra e o que não entra.

2. Qual é a visibilidade?

Normalmente:

public class Player

Pergunte:

"Essa classe precisa ser acessada por outras partes do sistema?"

Se sim, public.

Existem casos de internal, private etc., mas para começar, public será muito comum.

3. É class, record, interface, enum...?

Pergunte o que a coisa representa.

Player          → class
PlayerDto       → record
IPlayerRepository → interface
CategoriaNivel  → enum

Isso é mais importante do que decorar sintaxe.

4. Quais são os dados que a classe precisa guardar?

Agora pense nos atributos/estado.

No seu Player:

private readonly List<Categoria> _categorias = [];

public string Nome { get; private set; } = string.Empty;

Pergunte:

"O que um Player precisa saber para existir?"

Você chegou em:

Nome
Categorias

Não coloque automaticamente tudo como propriedade pública. Pense em quem pode alterar cada dado.

5. Quais invariantes/regras precisam ser protegidas?

Essa parte é especialmente importante no seu DDD.

Seu Player tem:

private const int MaxPontos = 16;

E:

if (pontosSemCategoria + novosPontos > MaxPontos)
{
    throw new InvalidOperationException(...);
}

Pergunte:

"O que nunca pode ser permitido nessa classe?"

Essas regras normalmente pertencem à própria entidade/agregado.

6. Como o objeto pode ser criado?

Agora pense no construtor.

Você tem:

private Player(string nome)

e:

public static Player Criar(string nome)

Isso é uma escolha interessante para seu domínio.

O construtor é privado porque você quer que a criação passe por:

Player.Criar(nome)

Em uma classe simples, poderia ser:

public Player(string nome)

Então a pergunta não é simplesmente:

"Preciso de um construtor?"

É:

"Como quero permitir que essa classe seja criada?"

7. Quais operações essa classe oferece?

Agora pense nos comportamentos.

No Player:

public void MudarCategoria(...)

Pergunte:

"O que alguém precisa conseguir pedir para esse objeto fazer?"

No seu domínio:

Criar
Mudar categoria
Adicionar categoria?
Remover categoria?

E aí transforme essas ações em métodos.

8. Qual deve ser a visibilidade dos métodos?

Por exemplo:

public void MudarCategoria(...)

é público porque outra parte do sistema precisa poder dizer:

"Player, mude sua categoria."

Já um método auxiliar poderia ser:

private void ValidarPontos(...)

se só a própria classe precisa dele.

Uma regra mental simples:

public  → outras partes do sistema podem pedir isso
private → detalhe interno da implementação
9. Existem dependências externas?

Só depois pense:

"Essa classe precisa de alguma outra classe para funcionar?"

Por exemplo, seu Service:

public class PlayerService
{
    private readonly IPlayerRepository _repository;

    public PlayerService(IPlayerRepository repository)
    {
        _repository = repository;
    }
}

Aqui você percebeu:

PlayerService
     ↓ precisa de
IPlayerRepository

Então cria o campo e recebe a dependência pelo construtor.

10. Só então escreva a implementação dos métodos

A estrutura vai ficando:

public class PlayerService
{
    // 1. Campos
    private readonly IPlayerRepository _repository;

    // 2. Construtor
    public PlayerService(IPlayerRepository repository)
    {
        _repository = repository;
    }

    // 3. Métodos públicos
    public async Task<PlayerDto?> ObterAsync(Guid id)
    {
        // implementação
    }
}
Seu checklist mental

Quando encontrar uma classe vazia, faça estas perguntas nessa ordem:

1. O que essa classe representa/faz?
        ↓
2. Quem precisa enxergá-la? → public/internal
        ↓
3. É class, record, interface, enum...?
        ↓
4. Que estado ela precisa guardar?
        ↓
5. Quem pode alterar esse estado?
        ↓
6. Quais regras/invariantes ela precisa proteger?
        ↓
7. Como ela deve ser criada?
        ↓
8. Quais comportamentos ela oferece?
        ↓
9. Quais comportamentos são public/private?
        ↓
10. Ela depende de outras classes?
        ↓
11. Implemento os métodosg
*/
