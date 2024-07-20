using CoreLayer.Services.Categories;
using CoreLayer.Services.Users;
using DAL.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddRazorPages();

// Add MVC services.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme; // "Cookies"
    option.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    option.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(option =>
{
    option.LoginPath = "/Auth/Login";
    option.LogoutPath = "/Auth/Logout";
    option.ExpireTimeSpan = TimeSpan.FromDays(30);
});

builder.Services.AddDbContext<DB>(option =>
{
    option.UseSqlServer(configuration.GetConnectionString("Default"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// Map controller routes for MVC Areas
app.MapControllerRoute(
    name: "Default",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

//Or:

//app.UseEndpoints(endpoints =>
//{
//    // Map controller routes for MVC Areas
//    endpoints.MapControllerRoute(
//        name: "areas",
//        pattern: "{controller=Home}/{action=Index}/{id?}");

//    endpoints.MapAreaControllerRoute(
//        name: "AdminPanel",
//        areaName: "Admin",
//        pattern: "CustomRoute/{controller=Home}/{action=Index}/{id?}");

//    // Map Razor Pages
//    endpoints.MapRazorPages();
//});

//app.MapGet("/", () => { Console.WriteLine("Hello Erfan!"); });

app.Run();
