using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using TazeBlog.Business.Abstract;
using TazeBlog.Business.Concrete;
using TazeBlog.Business.DependencyResolvers.Ninject;
using TazeBlog.Core.Utilities.Abstract;
using TazeBlog.Core.Utilities.Concrete;
using TazeBlog.DataAccess.Abstract;
using TazeBlog.DataAccess.Concrete.Dapper;

namespace TazeBlog.WebUI
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(option =>
                    {
                       option.LoginPath = new PathString("/Admin/User/Login");
                    });

            services.AddMvc();
            services.AddTransient<IArticleService, ArticleManager>();
            services.AddTransient<IArticleDal, DapArticleDal>();

            services.AddTransient<ICategoryService, CategoryManager>();
            services.AddTransient<ICategoryDal, DapCategoryDal>();

            services.AddTransient<IUserService, UserManager>();
            services.AddTransient<IUserDal, DapUserDal>();

            services.AddTransient<ICryptoService, AesCrypto>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc(ConfigureRoutes);
            app.UseStaticFiles();

        }

        private void ConfigureRoutes(IRouteBuilder routes)
        {
            routes.MapRoute(
              name: "area",
              template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            );

            routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}"
            );

        }
    }
}
