using BlazorApp;
using BlazorApp.Services;
using DotNetEnv;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7165/api/") });

builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<ParentService>();

await builder.Build().RunAsync();
