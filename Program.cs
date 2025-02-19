using BlazorSportStoreAuth;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorSportStoreAuth.Models;
using Blazored.LocalStorage;
using BlazorSportStoreAuth.Services.Authentication;
using BlazorSportStoreAuth.Services;
using BlazorSportStoreAuth.Interfaces;
using System;
using System.Net.Http;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Define the API Base URL
//var apiBaseUrl = "http://localhost:5000";
var apiBaseUrl = "https://nice-pebble-0d420e91e.4.azurestaticapps.net/"; // Ensure HTTPS

builder.Services.AddSingleton(new ApiSettings { BaseUrl = apiBaseUrl });
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiBaseUrl) });

builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("Local", options.ProviderOptions);
});

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<CartService>();
builder.Services.AddScoped<IItemListService, ItemListService>();
builder.Services.AddScoped<IProductOrderInfo, ProductOrderInfoManager>();
builder.Services.AddScoped<IProductOrderItems, ProductOrderItemsManager>();

await builder.Build().RunAsync();
