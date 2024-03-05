using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using TarefaNinja.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var configuration = builder.Configuration;
var baseUri = configuration["BaseUrl"];

ArgumentNullException.ThrowIfNull(baseUri);

var httpClient = new HttpClient
{
    BaseAddress = new Uri(baseUri),
};

httpClient.DefaultRequestHeaders.Add("X-Api-Version", "1");

builder.Services.AddScoped(sp => httpClient);

await builder.Build().RunAsync();
