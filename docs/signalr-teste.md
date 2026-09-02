# Teste do SignalR

Passo a passo para validar a comunicação em tempo real via `CacsHub`.

## Pré-requisitos

- .NET 10 SDK instalado
- Node.js 22+ (para compilar o Tailwind CSS)
- Repositório clonado e restaurado

```powershell
dotnet restore
cd Cacs.Web
npm install
```

## 1. Subir a aplicação

Na raiz do repositório:

```powershell
dotnet run --project Cacs.Web
```

Anote a URL exibida no terminal (ex.: `https://localhost:7123`).

O CSS do Tailwind é gerado automaticamente no `dotnet build`. Durante o desenvolvimento de UI, você pode deixar o watch ativo em outro terminal:

```powershell
cd Cacs.Web
npm run watch:css
```

## 2. Abrir a página de teste

No navegador, acesse a raiz da aplicação:

```
/
```

Exemplo completo: `https://localhost:7123/`

## 3. Conectar ao hub

1. Clique em **Conectar**
2. O status deve mudar para **Conectado**

Se aparecer erro, confira:

- A aplicação está rodando
- A URL usa o mesmo host/porta do `dotnet run`
- Em Development, erros detalhados do SignalR estão habilitados

## 4. Testar broadcast entre abas

1. Abra uma **segunda aba** na mesma URL (`/`)
2. Clique em **Conectar** nas duas abas
3. Na aba 1, preencha **Usuário** e **Mensagem** e clique em **Enviar**
4. A mensagem deve aparecer na lista das **duas abas**

Formato exibido: `Usuário: Mensagem`

Isso confirma que o hub em `/hubs/cacs` está recebendo chamadas e fazendo broadcast via `ReceiveMessage`.

## 5. Inspecionar a conexão (opcional)

No DevTools do navegador (F12):

1. Aba **Network**
2. Filtro **WS** (WebSocket)
3. Procure a conexão com `hubs/cacs`
4. Ao enviar mensagens, frames devem aparecer na conexão

Também é possível validar o endpoint de negociação acessando:

```
/hubs/cacs/negotiate
```

Deve retornar JSON com `connectionToken` e `availableTransports`.

## O que está sendo testado

| Peça | Local |
|------|-------|
| Hub `SendMessage` / `ReceiveMessage` | `Cacs.Infrastructure/SignalR/Hubs/CacsHub.cs` |
| Registro e JSON do SignalR | `Cacs.Infrastructure/DependencyInjection.cs` |
| Mapeamento `/hubs/cacs` | `Cacs.Infrastructure/SignalR/SignalREndpointRouteBuilderExtensions.cs` |
| Página de teste | `Cacs.Web/Components/Pages/Categorias.razor` |

## Próximo passo no domínio

Quando implementar sincronização de fichas (RF10), o fluxo será:

1. Cliente altera dados via API REST
2. Application persiste a mudança
3. Application ou Infrastructure notifica o grupo via `IHubContext<CacsHub>`
4. Componentes Blazor escutam eventos como `CategoriaAtualizada` e atualizam a UI
