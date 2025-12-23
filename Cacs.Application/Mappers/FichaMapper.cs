using Cacs.Domain.Models;
using Cacs.Shared.Dtos;

namespace Cacs.Application.Mappers;

public static class FichaMapper
{
    public static FichaDto ToDto(this Ficha f)
    {
        // observação: abaixo faço escolhas “simples” para não vazar internals
        var atributos = f.Atributos
            .Select(a => new AtributoDto(a.NomeAtributo.ToString(), a.Valor))
            .ToList();

        var pericias = f.Pericias
            .Select(p => new PericiaDto(
                Nome: p.NomePericia.ToString(),
                AtributoBase: "—", // futuramente você pode mapear isso a partir da perícia
                Bonus: p.NivelTreinamento.ObterBonus(),
                Treino: p.NivelTreinamento.Nivel.ToString(),
                Outros: p.OutrosBonus
            ))
            .ToList();


        var habilidades = f.Habilidades
            .Select(h => new HabilidadeDto(h.Nome, h.Descricao))
            .ToList();

        var itens = f.Itens
            .Select(i => new ItemDto(i.Nome, i.Descricao))
            .ToList();

        var rituais = f.Rituais
            .Select(r => new RitualDto(r.Nome, r.Circulo, r.Elemento.ToString(), r.DescricaoBase))
            .ToList();

        return new FichaDto(
            Id: Guid.NewGuid(), // ou f.Id se existir Guid
            NomePersonagem: f.NomePersonagem,
            NomeJogador: f.NomeJogador,
            NEX: f.NEX,
            PV: f.PV,
            PE: f.PE,
            SAN: f.SAN,
            Defesa: f.Defesa,
            Bloqueio: f.Bloqueio,
            Esquiva: f.Esquiva,
            Deslocamento: f.Deslocamento,
            Origem: f.Origem?.ToString() ?? "—", // use algo simples (nome)
            Classe: f.Classe?.GetType().Name ?? "—",
            Atributos: atributos,
            Pericias: pericias,
            Habilidades: habilidades,
            Itens: itens,
            Rituais: rituais
        );
    }
}
