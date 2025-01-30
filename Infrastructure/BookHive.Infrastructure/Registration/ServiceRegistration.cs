using BookHive.Application.Abstracts.Caching;
using BookHive.Application.Abstracts.Services;
using BookHive.Application.Abstracts;
using BookHive.Application.Configurations;
using BookHive.Infrastructure.Services;
using BookHive.Infrastructure.Services.Caching.Memory;
using BookHive.Infrastructure.Services.Configuration;
using BookHive.Infrastructure.Services.Mail;
using Microsoft.Extensions.DependencyInjection;

namespace BookHive.Infrastructure.Registration
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddMemoryCache();

            services.AddScoped<ITokenHandler, TokenHandler>();
            services.AddScoped<IMailService,MailService>();
            services.AddScoped<ICacheService,MemoryCacheService>();
            services.AddScoped<IApplicationService,ApplicationService>();
        }
    }
}
