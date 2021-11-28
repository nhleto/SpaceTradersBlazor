using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using SpaceTradersBlazor;
using SpaceTradersBlazor.Models;
using SpaceTradersBlazor.SpaceTradersClient;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();

var spaceTradersConfig = builder.Configuration.GetSection("SpaceTraders").Get<SpaceTradersConfig>();
builder.Services.AddHttpClient<SpaceTradersClient>(client =>
{
    client.BaseAddress = new Uri(spaceTradersConfig.StartupUrl);
});

await builder.Build().RunAsync();
