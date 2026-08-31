using Cacs.Infrastructure;
using Cacs.Infrastructure.SignalR;
using Cacs.Web.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddInfrastructure(builder.Environment);

var app = builder.Build();

app.UseInfrastructure();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapInfrastructureHubs();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
