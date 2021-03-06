using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Octopus.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Web.Optimization;
using Octopus.Models;
using Octopus.Services;
using System.Net.Http.Headers;

namespace Octopus
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment env { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            /*services.AddBundling()
                .UseDefaults(env)
                .UseNUglify();*/
            services.AddDistributedMemoryCache();
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/Logout";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            });
          

            services.AddSession(options =>
            {
                options.Cookie.Name = "UserData";
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<SignInManager<User>, SignInManager<User>>();
          
            services.AddDefaultIdentity<User>(options => {
          //services.AddIdentityCore<User> (options => {
                options.SignIn.RequireConfirmedAccount = false;
            }).AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddHttpClient("MXTAE", c =>
            {
                c.BaseAddress = new Uri("http://www.itmultiwebservice.net/wsdmm/fdmm.asmx");
                // Github API versioning
                c.DefaultRequestHeaders.Add("Accept", "application/soap+xml");
                c.DefaultRequestHeaders
      .Accept
      .Add(new MediaTypeWithQualityHeaderValue("application/soap+xml"));
                // Github requires a user-agent
                c.DefaultRequestHeaders.Add("Host", "www.itmultiwebservice.net");
            });
            services.AddHttpClient("MXTAED", c =>
            {
                c.BaseAddress = new Uri("http://www.itmultiwebservice.net/wsdmm/fdmmpaq.asmx");
                // Github API versioning
                c.DefaultRequestHeaders.Add("Accept", "application/soap+xml");
                c.DefaultRequestHeaders
      .Accept
      .Add(new MediaTypeWithQualityHeaderValue("application/soap+xml"));
                // Github requires a user-agent
                c.DefaultRequestHeaders.Add("Host", "www.itmultiwebservice.net");
            });
            services.AddHttpClient("Evolution", c =>
            {
                c.BaseAddress = new Uri("http://www.ventamovil.com.mx:9094/service.asmx/");
                // Github API versioning
                c.DefaultRequestHeaders.Add("Accept", "application/soap+xml");
                c.DefaultRequestHeaders
      .Accept
      .Add(new MediaTypeWithQualityHeaderValue("application/soap+xml"));
                // Github requires a user-agent
            });

            services.AddTransient<IUserData, UserData>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (true)
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
           /* app.UseBundling(bundles =>
            {
               
                bundles.AddJs("~/bundles/jqueryval")
                    .Include("~/Scripts/jquery.unobtrusive-ajax.js")
                    .Include("~/Scripts/jquery.unobtrusive-ajax.min.js")
                    .Include("~/Scripts/jquery.validate*")
                    .Include("~/Scripts/jquery.validate.unobtrusive.js")
                    .Include("~/Scripts/jquery.validate.unobtrusive.min.js");

                // and so on...
            });*/
            app.UseHttpsRedirection();
            app.UseStaticFiles(new StaticFileOptions()
            {
                OnPrepareResponse = context =>
                {
                    context.Context.Response.Headers.Add("Cache-Control", "no-cache, no-store");
                    context.Context.Response.Headers.Add("Expires", "-1");
                }
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
