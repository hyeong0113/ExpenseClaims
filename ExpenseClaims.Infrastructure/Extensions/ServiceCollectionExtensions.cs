using ExpenseClaims.Application.Interfaces.CacheRepositories;
using ExpenseClaims.Application.Interfaces.Contexts;
using ExpenseClaims.Application.Interfaces.Repositories;
using ExpenseClaims.Infrastructure.CacheRepositories;
using ExpenseClaims.Infrastructure.DbContexts;
using ExpenseClaims.Infrastructure.Repositories;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ExpenseClaims.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddPersistenceContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            #region Repositories

            services.AddTransient(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductCacheRepository, ProductCacheRepository>();
            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<IBrandCacheRepository, BrandCacheRepository>();
            services.AddTransient<ILogRepository, LogRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IExpenseClaimRepository, ExpenseClaimRepository>();
            services.AddTransient<IExpenseItemRepository, ExpenseItemRepository>();
            services.AddTransient<IExpenseCategoryRepository, ExpenseCategoryRepository>();
            services.AddTransient<ICurrencyRepository, CurrencyRepository>();


            #endregion Repositories
        }
    }
}