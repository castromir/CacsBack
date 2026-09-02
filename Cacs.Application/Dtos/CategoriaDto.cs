using Cacs.Domain.Models.Players;

namespace Cacs.Application.Dtos
{
    public record CategoriaDto(
        CategoriaNivel Nivel,
        int Quantidade,
        int Pontos
    );
}
