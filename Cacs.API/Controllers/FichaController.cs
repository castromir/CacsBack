using Cacs.Application.Mappers;
using Cacs.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;
using Cacs.Application.Services;

[ApiController]
[Route("api/[controller]")]
public class FichaController : ControllerBase
{
    private readonly IFichaService _service;

    public FichaController(IFichaService service)
    {
        _service = service;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<FichaDto>> Get(Guid id)
    {
        var ficha = await _service.ObterPorIdAsync(id); // retorna domínio
        if (ficha is null) return NotFound();

        var dto = ficha.ToDto();
        return Ok(dto);
    }
}
