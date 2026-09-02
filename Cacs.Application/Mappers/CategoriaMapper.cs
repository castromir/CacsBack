using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Cacs.Application.Dtos;
using Cacs.Domain.Models.Players;

namespace Cacs.Application.Mappers
{
    public static class CategoriaMapper
    {
        public static CategoriaDto ToDto(Categoria categoria)
        {
            return new CategoriaDto(
                categoria.Nivel,
                categoria.Quantidade,
                categoria.Pontos);
        }
    }
}
