using System.Data.Common;
using BookHive.Application.Abstracts.ServiceContracts;
using BookHive.Application.Abstracts.Services.Dapper;
using BookHive.Application.Abstracts.Services.EntityFramework;
using BookHive.Persistence.Concrete;
using BookHive.Persistence.ServiceContracts;
using BookHive.Persistence.Services.Dapper;
using BookHive.Persistence.Services.EntityFramework;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;

namespace BookHive.Persistence.Registration
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<Context>();
            services.AddScoped<DbConnection>(provider => new SqlConnection(Context.SqlConnection));


            services.AddScoped<IBasketService,BasketService>();
            services.AddScoped<IOrderService, OrderService>();

            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
            services.AddScoped<ICategoryReadDapper,CategoryReadDapper>();
            services.AddScoped<ICategoryWriteDapper,CategoryWriteDapper>();

            services.AddScoped<IPublisherReadRepository, PublisherReadRepository>();
            services.AddScoped<IPublisherWriteRepository, PublisherWriteRepository>();

            services.AddScoped<IGenreReadRepository, GenreReadRepository>();
            services.AddScoped<IGenreWriteRepository, GenreWriteRepository>();
            services.AddScoped<IGenreReadDapper,GenreReadDapper>();
            services.AddScoped<IGenreWriteDapper, GenreWriteDapper>();

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

            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();

        }
    }
}
