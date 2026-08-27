namespace Cacs.Application.Dtos;

public sealed record AtributoDto(string Nome, int Valor);

public sealed record PericiaDto(
    string Nome,
    string AtributoBase, // ex.: "FOR", "AGI" (texto simples)
    int Bonus,
    string Treino,       // ex.: "NT", "T", "VT" (ou texto claro)
    int Outros
);

public sealed record HabilidadeDto(string Nome, string? Descricao);

public sealed record ItemDto(string Nome, string? Descricao);

public sealed record RitualDto(string Nome, int? Circulo, string? Elemento, string? DescricaoBase);

public sealed record FichaDto(
    Guid Id,
    string NomePersonagem,
    string NomeJogador,
    int NEX,
    int PV,
    int PE,
    int SAN,
    int Defesa,
    int Bloqueio,
    int Esquiva,
    string Deslocamento,
    string Origem,        // representação simples (ex.: nome)
    string Classe,        // representação simples (ex.: nome da classe)
    IReadOnlyList<AtributoDto> Atributos,
    IReadOnlyList<PericiaDto> Pericias,
    IReadOnlyList<HabilidadeDto> Habilidades,
    IReadOnlyList<ItemDto> Itens,
    IReadOnlyList<RitualDto> Rituais
);
