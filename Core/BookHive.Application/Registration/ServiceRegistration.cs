using BookHive.Application.Mappers.AutoMapper;
using BookHive.Application.Rules.Abstract;
using BookHive.Application.Rules.Concrete;
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

            services.AddScoped<ICategoryRuleService,CategoryRuleService>();
            services.AddScoped<IBookLanguageRuleService,BookLanguageRuleService>();
            services.AddScoped<IBookStatusRuleService,BookStatusRuleService>();
            services.AddScoped<IPublisherRuleService,PublisherRuleService>();
            services.AddScoped<IGenreRuleService,GenreRuleService>();
            services.AddScoped<IAuthorRuleService,AuthorRuleService>();
            services.AddScoped<IBookRuleService,BookRuleService>();
        }
    }
}
