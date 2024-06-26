using Microsoft.AspNetCore.Authentication.Cookies;

namespace PRN221_Project_Blog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages() ;
            builder.Services.AddDistributedMemoryCache();

            //builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
            //options =>
            //{
            //    options.LoginPath = new PathString("/login");
            //    options.AccessDeniedPath = "/AccessDenied.html";
            //});

            builder.Services.AddSession(cfg => {            
                cfg.Cookie.Name = "foodblog";             
                cfg.IdleTimeout = new TimeSpan(0, 5, 0);  
            });

            

            var app = builder.Build();
            app.UseSession();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}