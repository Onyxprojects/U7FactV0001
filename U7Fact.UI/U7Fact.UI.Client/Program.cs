using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using U7Fact.Services;
using U7Fact.Services.Contracts;
using U7Fact.UI.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddHttpClient<IParticuliereKlantService, ParticuliereKlantHttpService>(options =>
{
    options.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});

await builder.Build().RunAsync();