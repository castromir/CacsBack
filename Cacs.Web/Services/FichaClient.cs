using System.Net.Http.Json;
using Cacs.Shared.Dtos;

namespace Cacs.Web.Services;

public class FichaClient
{
    private readonly HttpClient _http;

    public FichaClient(HttpClient http) => _http = http;

    public async Task<FichaDto?> ObterFichaAsync(Guid id)
        => await _http.GetFromJsonAsync<FichaDto>($"ficha/{id}");
}
