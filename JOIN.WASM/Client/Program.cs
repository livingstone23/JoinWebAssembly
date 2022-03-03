using JOIN.WASM.Client;
using JOIN.WASM.Client.ViewModels;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");


builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSingleton<IProfileViewModel, ProfileViewModel>();
builder.Services.AddSingleton<IContactsViewModel, ContactsViewModel>();
builder.Services.AddSingleton<ISettingsViewModel, SettingsViewModel>();

await builder.Build().RunAsync();



////Starting method GetProfile
///Capitol 08
//var host = builder.Build();

//var profileViewModel = host.Services.GetRequiredService<IProfileViewModel>();
//profileViewModel.GetProfile();

//await host.RunAsync();
