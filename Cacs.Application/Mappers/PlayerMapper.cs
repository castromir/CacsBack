using System;
using System.Collections.Generic;
using System.Text;
using Cacs.Application.Dtos;
using Cacs.Domain.Models.Players;

namespace Cacs.Application.Mappers
{
    public static class PlayerMapper
    {
        public static PlayerDto ToDto(Player player)
        {
            var categorias = player.Categorias
                .Select(CategoriaMapper.ToDto)
                .ToList();

            return new PlayerDto(
                player.Id,
                player.Nome,
                categorias);
        }
    }
}
