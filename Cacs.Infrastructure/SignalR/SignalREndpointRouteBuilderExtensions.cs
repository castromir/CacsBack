using Cacs.Infrastructure.SignalR.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Cacs.Infrastructure.SignalR;

public static class SignalREndpointRouteBuilderExtensions
{
    public static IEndpointRouteBuilder MapInfrastructureHubs(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapHub<CacsHub>("/hubs/cacs");
        return endpoints;
    }
}
