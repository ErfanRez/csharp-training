using CoreLayer.Services;
using CoreLayer.Services.Categories;
using CoreLayer.Services.Comments;
using CoreLayer.Services.FileManager;
using CoreLayer.Services.Posts;
using CoreLayer.Services.Users;
using DataLayer.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
services.AddRazorPages()
                .AddRazorRuntimeCompilation();

services.AddControllersWithViews();
services.AddScoped<IUserService, UserService>();
services.AddScoped<ICategoryService, CategoryService>();
services.AddTransient<IPostService, PostService>();
services.AddTransient<IFileManager, FileManager>();
services.AddTransient<ICommentService, CommentService>();
services.AddTransient<IMainPageService, MainPageService>();
services.AddDbContext<BlogContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
services.AddAuthorization(option =>
{
    option.AddPolicy("AdminPolicy", builder =>
    {
        builder.RequireRole("Admin");
    });
});

services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    option.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(option =>
{
    option.LoginPath = "/Auth/Login";
    option.LogoutPath = "/Auth/Logout";
    option.ExpireTimeSpan = TimeSpan.FromDays(30);
    option.AccessDeniedPath = "/";
});

var app = builder.Build();
if (!builder.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/ErrorHandler/500");
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/ErrorHandler/{0}");

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