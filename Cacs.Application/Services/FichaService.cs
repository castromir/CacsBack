using Cacs.Domain.Models;
using Cacs.Domain.Models.Classe;
using Cacs.Domain.Models.Enums;

namespace Cacs.Application.Services;

sealed class ClasseFake : ClasseBase
{
    public ClasseFake()
    {
        this.PontosVidaInicial = 10;
        this.PontosEsforcoInicial = 5;
        this.SanidadeInicial = 5;
        this.BonusPontosVida = 2;
        this.BonusPontosEsforco = 1;
        this.BonusSanidade = 1;
    }

    public override void CalcularAtributos()
    {
        // Mock: sem lógica
    }
}

sealed class OrigemFake : Origem
{
    public OrigemFake() : base(
        nome: "Militar",
        descricao: "Origem de teste para mock",
        periciasTreinadas: new List<Pericia>
        {
            new Pericia(NomePericia.Luta),
            new Pericia(NomePericia.Pontaria)
        },
        habilidade: new Habilidade(
            nome: "Sobrevivente",
            descricao: "Capaz de resistir a condições adversas.",
            fonte: FonteHabilidade.Origem // 👈 novo parâmetro obrigatório
        )
    )
    { }
}


public class FichaService : IFichaService
{
    public Task<Ficha?> ObterPorIdAsync(Guid id)
    {
        var classeFake = new ClasseFake();
        var origemFake = new OrigemFake();

        var ficha = new Ficha(
            nomePersonagem: "Kael",
            nex: 5,
            classe: classeFake,
            origem: origemFake
        );

        return Task.FromResult<Ficha?>(ficha);
    }
}
