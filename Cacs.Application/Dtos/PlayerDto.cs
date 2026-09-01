using System;
using System.Collections.Generic;
using System.Text;
using Cacs.Domain.Models.Players;

namespace Cacs.Application.Dtos
{
    public record PlayerDto(
        Guid Id,
        string Nome,
        IReadOnlyList<CategoriaDto> Categorias
    );  
}
