using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using WebApp.Data;
using WebApp.Repositories;

namespace WebApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddDbContext<AgriculturalProductsContext>(options =>
                                        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Custom Identity
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                                .AddEntityFrameworkStores<AgriculturalProductsContext>()
                                .AddDefaultUI()
                                .AddDefaultTokenProviders();

            builder.Services.AddRazorPages();

            // Bổ sung role để tùy chỉnh giao diện
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdmin", policy => policy.RequireRole("Admin"));
            });
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireMember", policy => policy.RequireRole("Member"));
            });


            builder.Services.AddScoped<ISanPhamRepository, EFProductRepository>();
            builder.Services.AddScoped<ICategoryRepository, EFCategoryRepository>();

            // Add services to the container.
            builder.Services.AddControllersWithViews()
                .AddJsonOptions(o =>
                {
                    o.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                    o.JsonSerializerOptions.PropertyNamingPolicy = null;
                });
                
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //Thêm vào để Identity hoạt động
            app.MapRazorPages();
            app.UseAuthentication(); ;

            app.UseAuthorization();

            //Route to Admin page
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=DashBoard}/{action=Index}/{id?}"
                );
            });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");


            /*//Khoi tao role
            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var roles = new[] { "Admin", "Member" };
                foreach (var item in roles)
                {
                    if (!await roleManager.RoleExistsAsync(item))
                    {
                        await roleManager.CreateAsync(new IdentityRole(item));
                    }
                }
            }*/

            app.Run();
        }
    }
}