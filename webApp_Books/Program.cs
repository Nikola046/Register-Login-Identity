using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using webApp_Books.Data;
using webApp_Books.Models;
using webApp_Books.Repository;
using webApp_Books.Repository.SQL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<EFDBcontext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"));
});

builder.Services.AddScoped<IBookRepository,BookSQLRepository>();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<EFDBcontext>().AddDefaultTokenProviders();


builder.Services.Configure<IdentityOptions>(opcije => {
    // Podesavanje lozinke
    opcije.Password.RequireDigit = false;
    opcije.Password.RequiredLength = 3;
    opcije.Password.RequireNonAlphanumeric = false;
    opcije.Password.RequireUppercase = false;
    opcije.Password.RequireLowercase = false;
    opcije.Password.RequiredUniqueChars = 1;
    // Podesavanje korisnika
    opcije.User.RequireUniqueEmail = false;
});

builder.Services.ConfigureApplicationCookie(opcije =>
{
    // Cookie settings
    opcije.Cookie.HttpOnly = true;
    opcije.ExpireTimeSpan = TimeSpan.FromMinutes(5);
    opcije.LoginPath = "/Account/LogIn";
    opcije.AccessDeniedPath = "/Account/AccessDenied";
    opcije.SlidingExpiration = true;
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

app.UseAuthorization();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
