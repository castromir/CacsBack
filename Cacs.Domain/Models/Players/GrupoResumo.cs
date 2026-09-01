using Cacs.Domain.Models.Players;

public sealed record GrupoResumo(
    int PontosUtilizados,
    int LimiteTotal,
    int PontosDisponiveis)
{
    public static GrupoResumo Calcular(
        IEnumerable<Player> players)
    {
        var lista = players.ToList();

        var limiteTotal = lista.Count * 16;
        var pontosUtilizados = lista.Sum(p => p.Pontos);
        var pontosDisponiveis = limiteTotal - pontosUtilizados;

        return new GrupoResumo(
            pontosUtilizados,
            limiteTotal,
            pontosDisponiveis);
    }
}
