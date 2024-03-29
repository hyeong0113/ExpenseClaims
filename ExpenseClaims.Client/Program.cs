using AutoMapper;
using Blazored.LocalStorage;
using ExpenseClaims.Client.Auth;
using ExpenseClaims.Client.Contracts;
using ExpenseClaims.Client.Services;
using ExpenseClaims.Client.Services.Base;
using MediatR;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseClaims.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

            builder.Services.AddSingleton(new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44377")
            });

            builder.Services.AddHttpClient<IBaseClient, BaseClient>(_ =>
                new BaseClient(
                    "https://localhost:44377",
                    new HttpClient
                    {
                        BaseAddress = new Uri("https://localhost:44377")
                    }
                )
             );

            builder.Services.AddMudServices();
            builder.Services.AddBlazoredLocalStorage(config =>
                config.JsonSerializerOptions.WriteIndented = true);

            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
            builder.Services.AddScoped<IExpenseClaimService, ExpenseClaimService>();
            builder.Services.AddScoped<IExpenseItemService, ExpenseItemService>();
            builder.Services.AddScoped<IExpenseCategoryService, ExpenseCategoryService>();
            builder.Services.AddScoped<ICurrencyService, CurrencyService>();

            builder.Services.AddApiAuthorization();
            builder.Services.AddApiAuthorization()
                .AddAccountClaimsPrincipalFactory<CustomUserFactory>();

            builder.Services.AddMediatR(typeof(Program));

            await builder.Build().RunAsync();
        }
    }
}
