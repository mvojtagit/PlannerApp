using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PlannerApp.Shared.Services;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Tewr.Blazor.FileReader;

namespace PlannerAppClient
{
    public class Program
    {

        //https://plannerappserver20200228091432.azurewebsites.net/

        private const string url = "https://plannerappserver20200228091432.azurewebsites.net";
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            //za local storage
            builder.Services.AddBlazoredLocalStorage();
            //auth NuGet Ms.AspNetCore.Comp.Auth
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddFileReaderService(options => 
            {
                options.UseWasmSharedBuffer = true;
                
             });

            builder.Services.AddScoped<AuthenticationStateProvider, LocalAuthenticationStateProvider>();
            builder.Services.AddScoped<AuthenticationService>(x =>
                {
                    return new AuthenticationService(url);
                });

            builder.Services.AddScoped<PlansService>(x =>
            {
                return new PlansService(url);
            });

            builder.Services.AddScoped<ToDoItemsService>(x =>
            {
                return new ToDoItemsService(url);
            });

            builder.RootComponents.Add<App>("app");

            await builder.Build().RunAsync();
        }
    }
}
