using BookHive.Application.Abstracts.Services;
using BookHive.Persistence.Concrete;
using BookHive.Persistence.Context;
using Microsoft.Extensions.DependencyInjection;

namespace BookHive.Persistence.Registration
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>();

            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();

            services.AddScoped<IBookLanguageReadRepository, BookLanguageReadRepository>();
            services.AddScoped<IBookLanguageWriteRepository, BookLanguageWriteRepository>();    

            services.AddScoped<IBookStatusReadRepository, BookStatusReadRepository>();
            services.AddScoped<IBookStatusWriteRepository, BookStatusWriteRepository>();

            services.AddScoped<IPublisherReadRepository, PublisherReadRepository>();
            services.AddScoped<IPublisherWriteRepository, PublisherWriteRepository>();

            services.AddScoped<IGenreReadRepository, GenreReadRepository>();
            services.AddScoped<IGenreWriteRepository, GenreWriteRepository>();

            services.AddScoped<IAuthorReadRepository, AuthorReadRepository>();
            services.AddScoped<IAuthorWriteRepository, AuthorWriteRepository>();

            services.AddScoped<IBookReadRepository, BookReadRepository>();
            services.AddScoped<IBookWriteRepository, BookWriteRepository>();

            services.AddScoped<IEndpointReadRepository, EndpointReadRepository>();
            services.AddScoped<IEndpointWriteRepository, EndpointWriteRepository>();

            services.AddScoped<IMenuReadRepository, MenuReadRepository>();
            services.AddScoped<IMenuWriteRepository, MenuWriteRepository>();
        }
    }
}
