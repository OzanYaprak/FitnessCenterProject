using Antreman.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("conn");
builder.Services.AddDbContext<antremanDBContext>(options => options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddControllersWithViews();

//LOGÝN ÝÞLEMLERÝ ÝÇÝN ÝLAVE GELEN (baþlangýc)

builder.Services.Configure<Microsoft.AspNetCore.Mvc.CookieTempDataProviderOptions>(options =>
{
    options.Cookie.IsEssential=true;
}); 

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded= context => true;
    options.MinimumSameSitePolicy= SameSiteMode.None;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = "/Hesap/Giris";
    options.AccessDeniedPath = "/Hesap/Giris";
    options.LogoutPath = "/Hesap/Giris";
});

//LOGÝN ÝÞLEMLERÝ ÝÇÝN ÝLAVE GELEN (bitiþ)




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

app.UseCookiePolicy(); //LOGÝN ÝÞLEMLERÝ ÝÇÝN
app.UseAuthentication(); //LOGÝN ÝÞLEMLERÝ ÝÇÝN

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
