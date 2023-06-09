using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyBlog.Repositories;
using MyBlog.Repositories.Interfaces;
using MyBlog.Servises;
using MyBlog.Servises.Interfaces;
using System;

namespace MyBlog
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MyBlogDbContext>(x => x.UseSqlServer("Server=DESCTOP-V9GRIC;Database=MyBlog;Trusted_Connection=true;"));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
                options =>
                {
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                    options.SlidingExpiration = true;
                    options.LoginPath = "/Auth/SignIn";
                }
                );

            services.AddAuthorization(options =>
            {
                options.AddPolicy("IsAdmin", policy =>
                {
                    policy.RequireClaim("IsAdmin", "True");

                });
            });

            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddTransient<IMyBlogsServise, MyBlogsServise>();
            services.AddTransient<IMyBlogsRepository, BlogsRepository>();

            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IUsersRepository, UsersRepository>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=MyBlogs}/{action=Overview}/{id?}");
            });
        }
    }
}
