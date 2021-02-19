using ExpenseClaims.Api.Extensions;
using ExpenseClaims.Api.Middlewares;
using ExpenseClaims.Application.Extensions;
using ExpenseClaims.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;

namespace ExpenseClaims.Api
{
    public class Startup
    {
        //readonly string AllowClaimExpenseWeb = "Default";

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration _configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {   // 이 방법은 나중에 controller마다 annotation을 달아야함
            //services.AddCors(options =>
            //{
            //    options.AddPolicy(name: AllowClaimExpenseWeb,
            //                      builder =>
            //                      {
            //                          builder.WithOrigins("https://localhost:44340", "https://expensewinapp.azurewebsites.net")
            //                                .AllowAnyMethod()
            //                                .WithHeaders(HeaderNames.ContentType, HeaderNames.Authorization, "x-custom-header")
            //                                .AllowCredentials();
            //                      });
            //});

            services.AddCors(options => options.AddDefaultPolicy(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

            services.AddApplicationLayer();
            services.AddContextInfrastructure(_configuration);
            services.AddPersistenceContexts(_configuration);
            services.AddRepositories();
            services.AddSharedInfrastructure(_configuration);
            services.AddEssentials();
            services.AddControllers();
            services.AddMvc(o =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                o.Filters.Add(new AuthorizeFilter(policy));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.ConfigureSwagger();
            app.UseHttpsRedirection();
            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseRouting();

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}