using GraphiQl;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SiteNewsApi.Models;
using SiteNewsApi.Models.GraphQL;
using SiteNewsApi.Repositories.ImplementedRepository;
using SiteNewsApi.Repositories.InterfaceRepository;
using SiteNewsApi.UnitOfWorks;

namespace SiteNewsApi
{
    public class Startup
    {
       public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
       public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddScoped<DbContext, NewsContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<INewsRepository, NewsRepository>();


            services.AddSingleton<NewsQuery>();
            services.AddSingleton<UserQuery>();

            services.AddSingleton<NewsType>();
            services.AddSingleton<UserType>();
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("MyPolicy"));
            });

            var sp = services.BuildServiceProvider();

          // services.AddSingleton<ISchema>(new UsersSchema(new FuncDependencyResolver(type => sp.GetService(type))));
            services.AddSingleton<ISchema>(new NewsSchema(new FuncDependencyResolver(type => sp.GetService(type))));


        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseGraphiQl();
            app.UseMvc();

            app.UseCors("MyPolicy");
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("hello world!");
            });
        }
    }
}
