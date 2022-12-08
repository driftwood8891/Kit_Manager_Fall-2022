using Kit_Manager_Fall_2022.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kit_Manager_Fall_2022
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();
            //***Add this line to enable RazorRuntimeCompilation, download Install-Package Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation -Version 3.0.0
            services.AddRazorPages().AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
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

            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("X-Xss-Protection", "1");              // Protects against JavaScript Injection Attacks (XSS)
                context.Response.Headers.Add("X-Frame-Options", "SAMEORIGIN");      // Protects against cross-site scripting attacks (HTML iframes)
                context.Response.Headers.Add("X-Content-Type-Options", "nosniff");  // Protects against MIME sniffing (XSS)
                context.Response.Headers.Add("Referrer-Policy", "no-referrer");     // Controls info the browser should reveal to the web server
                context.Response.Headers.Add("Expect-CT", "max-age=0");             // Prevent website certificate spoofing
                context.Response.Headers.Add("Feature-Policy",
                    "vibrate 'self' ; " +
                    "camera 'self' ; " +
                    "microphone 'self' ; " +
                    "speaker 'self' https://youtube.com https://www.youtube.com ;" +
                    "geolocation 'self' ; " +
                    "gyroscope 'self' ; " +
                    "magnetometer 'self' ; " +
                    "midi 'self' ; " +
                    "sync-xhr 'self' ; " +
                    "push 'self' ; " +
                    "notifications 'self' ; " +
                    "fullscreen '*' ; " +
                    "payment 'self' ; ");                                             // Denies access to browser features such as camera and mic 

                //context.Response.Headers.Add(
                //    "Content-Security-Policy-Report-Only",
                //    "default-src 'self'; http://www.w3.org/2000/svg" +
                //    "script-src-elem 'self'" +
                //    "style-src-elem 'self'; https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.css " +
                //    "img-src 'self'; http://www.w3.org/" +
                //    "font-src 'self'" +
                //    "media-src 'self'" +
                //    "frame-src 'self'" +
                //    "connect-src "
                //);                                                                    // Controls permitted content sources (XSS)
                await next();
            });

            app.UseHttpsRedirection();      // Redirects HTTP requests to HTTPS
            app.UseStaticFiles();           // Allows use of static files (CSS, JS, images)

            app.UseRouting();               // Adds route matching to the middleware pipeline

            app.UseAuthentication();        // Forces users to be authenticated
            app.UseAuthorization();         // Ensures that authentication and authorization are used by your web app

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
