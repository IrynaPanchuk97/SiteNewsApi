using GraphiQl;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            services.AddTransient<INewsRepository, NewsRepository>();
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            //services.AddDbContext<NewsContext>(option =>
            //option.UseSqlServer(Configuration.GetConnectionString("DevConnection")));


             services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            services.AddSingleton<NewsQuery>();
            services.AddScoped<DbContext, NewsContext>();
            //    services.AddSingleton<UserQuery>();
            services.AddSingleton<NewsType>();
          //  services.AddSingleton<UserType>();
            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new NewsSchema(new FuncDependencyResolver(type => sp.GetService(type))));
           // services.AddSingleton<ISchema>(new UsersSchema(new FuncDependencyResolver(type => sp.GetService(type))));

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseGraphiQl();
            app.UseMvc();


            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("hello world!");
            });
        }
    }
}
