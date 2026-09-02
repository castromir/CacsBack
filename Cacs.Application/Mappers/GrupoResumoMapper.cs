using System;
using System.Collections.Generic;
using System.Text;
using Cacs.Application.Dtos;
using Cacs.Domain.Models.Players;

namespace Cacs.Application.Mappers
{
    public static class GrupoResumoMapper
    {
        public static GrupoResumoDto ToDto(GrupoResumo grupoResumo)
        {
            return new GrupoResumoDto(
                grupoResumo.PontosUtilizados,
                grupoResumo.LimiteTotal,
                grupoResumo.PontosDisponiveis);
        }
    }
}
