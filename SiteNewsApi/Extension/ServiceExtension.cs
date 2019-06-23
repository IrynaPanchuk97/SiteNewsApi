using AutoMapper;
using GraphQL;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SiteNewsApi.Models;
using SiteNewsApi.Models.GraphQL;
using SiteNewsApi.Models.Mappings;
using SiteNewsApi.Repositories.ImplementedRepository;
using SiteNewsApi.Repositories.InterfaceRepository;
using SiteNewsApi.UnitOfWorks;

namespace SiteNewsApi.Extension
{
    public static class ServiceExtension
    {
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddSingleton(new MapperConfiguration(
                c =>
                {
                    c.AddProfile(new UserProfile());
                    c.AddProfile(new NewsProfile());
                }

                ).CreateMapper());
        }

        public static void ConfigureModelRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<INewsRepository, NewsRepository>();

            services.AddScoped<DbContext, NewsContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
        public static void ConfigureGraphQL(this IServiceCollection services)
        {
            services.AddSingleton<NewsContextQuery>();
            services.AddSingleton<NewsContextMutation>();

            services.AddSingleton<NewsType>();
            services.AddSingleton<UserType>();
            services.AddSingleton<UserNewsType>();
            services.AddSingleton<UserNewsInputType>();
            services.AddSingleton<UserInputType>();

            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new NewsSchema(new FuncDependencyResolver(type => sp.GetService(type))));

        }
    }
}
