using BookHive.Application.Mappers.AutoMapper;
using BookHive.Application.Rules.Abstract;
using BookHive.Application.Rules.Concrete;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BookHive.Application.Registration
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ServiceRegistration));
            services.AddAutoMapper(typeof(DtoMapper));

            var config = TypeAdapterConfig.GlobalSettings;
            services.AddSingleton(config);
            services.AddScoped<IMapper,ServiceMapper>();

            config.Compile();

            services.AddScoped<ICategoryRuleService,CategoryRuleService>();
            services.AddScoped<IPublisherRuleService,PublisherRuleService>();
            services.AddScoped<IGenreRuleService,GenreRuleService>();
            services.AddScoped<IAuthorRuleService,AuthorRuleService>();
            services.AddScoped<IBookRuleService,BookRuleService>();
            services.AddScoped<IReviewRuleService,ReviewRuleService>();
            services.AddScoped<IDiscountRuleService,DiscountRuleService>();
        }
    }
}
