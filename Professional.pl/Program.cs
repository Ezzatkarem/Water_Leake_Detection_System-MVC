using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Professonal.DAL.Common;
using Professonal.DAL.DB;
using Professonal.DAL.Entities;
using Profissonal.PPL.Common;

namespace Profetional.pl
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

            // ⬇️⬇️⬇️ عدل السطر ده كده ⬇️⬇️⬇️
            builder.Services.AddControllersWithViews()
                .AddViewLocalization() // ⬅️ ده اللي ناقص
                .AddDataAnnotationsLocalization(); // ⬅️ ده اختياري للتحقق من صحة البيانات
            builder.Services.AddModularDataAccessLayer();
            builder.Services.AddModularBessinissLogicLayer();

            builder.Services.AddDbContext<ProfessionalDBContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<ProfessionalDBContext>()
                .AddDefaultTokenProviders();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
            });

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
               // app.UseHsts();
            }

          app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRequestLocalization();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            // Seeding
            using (var scope = app.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider
                                      .GetRequiredService<UserManager<AppUser>>();

                var adminEmail = builder.Configuration["AdminSettings:Email"];
                var adminPassword = builder.Configuration["AdminSettings:Password"];

                if (await userManager.FindByEmailAsync(adminEmail) == null)
                {
                    var admin = new AppUser
                    {
                        UserName = adminEmail,
                        Email = adminEmail,
                        FullName = "Admin"
                    };

                    await userManager.CreateAsync(admin, adminPassword);
                }
            }

            app.Run();
        }
    }
}