using Microsoft.EntityFrameworkCore;
using U7Fact.Data;
using U7Fact.Services;
using U7Fact.Services.Contracts;
using U7Fact.UI.Client.Pages;
using U7Fact.UI.Components;

var builder = WebApplication.CreateBuilder(args);

// Voeg server-side Blazor toe
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

// Voeg BlazorBootstrap toe voor server-side
builder.Services.AddBlazorBootstrap();

// Voeg scoped services voor klantservices toe
builder.Services.AddScoped<IBedrijfsKlantService, BedrijfsKlantService>();
builder.Services.AddScoped<IParticuliereKlantService, ParticuliereKlantService>();
builder.Services.AddScoped<IKlantService, KlantService>();

// Voeg de database context toe      
builder.Services.AddDbContext<DataContext>(options =>
{
    options.EnableSensitiveDataLogging();
    options.UseSqlServer("Server=localhost;Database=U7Fact;Trusted_Connection=True;Encrypt=False");
});

// Bouw de app
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(U7Fact.UI.Client._Imports).Assembly);

app.Run();