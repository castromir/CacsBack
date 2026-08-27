namespace Cacs.Domain.Models.Classe
{
    public class Especialista : ClasseBase
    {
        public Especialista()
        {
            this.PontosVidaInicial = 16;
            this.PontosEsforcoInicial = 3;
            this.SanidadeInicial = 16;

            this.BonusPontosVida = 3;
            this.BonusPontosEsforco = 3;
            this.BonusSanidade = 4;
        }

        public override void CalcularAtributos()
        {
        }
    }
}
