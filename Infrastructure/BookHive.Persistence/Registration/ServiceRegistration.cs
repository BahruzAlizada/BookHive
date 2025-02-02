using BookHive.Application.Abstracts.Services;
using BookHive.Persistence.Concrete;
using BookHive.Persistence.Services.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace BookHive.Persistence.Registration
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<Context>();

            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();

            services.AddScoped<IPublisherReadRepository, PublisherReadRepository>();
            services.AddScoped<IPublisherWriteRepository, PublisherWriteRepository>();

            services.AddScoped<IGenreReadRepository, GenreReadRepository>();
            services.AddScoped<IGenreWriteRepository, GenreWriteRepository>();

            services.AddScoped<IAuthorReadRepository, AuthorReadRepository>();
            services.AddScoped<IAuthorWriteRepository, AuthorWriteRepository>();

            services.AddScoped<IBookReadRepository, BookReadRepository>();
            services.AddScoped<IBookWriteRepository, BookWriteRepository>();

            services.AddScoped<IReviewReadRepository, ReviewReadRepository>();
            services.AddScoped<IReviewWriteRepository, ReviewWriteRepository>();

            services.AddScoped<IEndpointReadRepository, EndpointReadRepository>();
            services.AddScoped<IEndpointWriteRepository, EndpointWriteRepository>();

            services.AddScoped<IMenuReadRepository, MenuReadRepository>();
            services.AddScoped<IMenuWriteRepository, MenuWriteRepository>();

            services.AddScoped<IDiscountReadRepository, DiscountReadRepository>();
            services.AddScoped<IDiscountWriteRepository, DiscountWriteRepository>();

            services.AddScoped<ICouponReadRepository, CouponReadRepository>();
            services.AddScoped<ICouponWriteRepository, CouponWriteRepository>();
            
            services.AddScoped<IBasketReadRepository, BasketReadRepository>();
            services.AddScoped<IBasketWriteRepository, BasketWriteRepository>();

            services.AddScoped<IBasketItemReadRepository, BasketItemReadRepository>();
            services.AddScoped<IBasketItemWriteRepository, BasketItemWriteRepository>();

        }
    }
}
