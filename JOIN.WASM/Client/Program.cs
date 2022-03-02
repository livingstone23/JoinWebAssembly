using JOIN.WASM.Client;
using JOIN.WASM.Client.ViewModels;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSingleton<IProfileViewModel, ProfileViewModelV2>();


//Starting method GetProfile
var host = builder.Build();

var profileViewModel = host.Services.GetRequiredService<IProfileViewModel>();
profileViewModel.GetProfile();

await host.RunAsync();
